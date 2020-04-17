using System;
using UnityEngine;

namespace Jellyfish
{
    public class jellyInteraction : MonoBehaviour , IHandInteractable
    {
        public bool targeted = false;
        public Rigidbody mainBoneRigidbody;
        public GameObject tempIndicatorSphere;

        public JellyFishWandering jellyFishWandering;
        public JellyFishBoundary jellyFishBoundary;
        public PulsingMovement pulsingMovement;
        public float turnForce;

        private float distanceFromHand;
        private float distanceFromRayPoint;
        private float startPulseForce;
        public AnimationCurve pusleForceModifier;
        private HandInteractionScript Targeter;
        public float timer;

        public bool ableToBeControlled = true;

        private void Start()
        {
            startPulseForce = pulsingMovement.forceMultiplier;
        }
        private void Awake()
        {
            SceneTransition sceneTransition = FindObjectOfType<SceneTransition>();

            SceneTransition.JellyFishleaveEvent += StopBeingControlled;
        }

        public void StopBeingControlled()
        {
            ableToBeControlled = false;
            Targeter = null;
            targeted = false;
            
            tempIndicatorSphere.SetActive(false);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (timer < 0 && pulsingMovement.forceMultiplier != startPulseForce && !targeted)
            {
                pulsingMovement.forceMultiplier = startPulseForce;
            }
            else
            {
                timer -= Time.deltaTime;
                
            }
        }
        
        float SineWave( float x, float pulseSpeed)
        {
            float y = (Mathf.Sin(x *pulseSpeed * 2 * Mathf.PI)+1)/2 ;
        
            return y;
        }
        public bool TargetedByOther(HandInteractionScript h)
        {
           return (Targeter != h && Targeter != null);
        }

        public void OnHandInteractionGainFocus(HandInteractionScript h)
        {
            if (ableToBeControlled)
            {
                pulsingMovement.forceMultiplier = startPulseForce / 5f;
                Targeter = h;
                targeted = true;

                tempIndicatorSphere.SetActive(true);
            }


        }

        public void OnHandInteractionLoseFocus(HandInteractionScript h)
        {
            Targeter = null;
            targeted = false;
            
            tempIndicatorSphere.SetActive(false);
        }
    

        public void OnHandInteractTriggerDown(HandInteractionScript h)
        {
            if (ableToBeControlled)
            {
                distanceFromHand = 2 + Vector3.Distance(transform.position, h.transform.position);
            }
        }

        public void OnHandInteractTrigger(HandInteractionScript h)
        {
            if (ableToBeControlled)
            {
                Vector3 t = h.targetRay.GetPoint(distanceFromHand);
                pulsingMovement.enabled = true;
                pulsingMovement.forceMultiplier =
                    10 + pusleForceModifier.Evaluate(Vector3.Distance(transform.position, t) / distanceFromHand);
                jellyFishBoundary.LookToward(t);
                timer = 2f;
            }
        }

        public void OnHandInteractTriggerUp(HandInteractionScript h)
        {
            if (ableToBeControlled)
            {
                pulsingMovement.enabled = false;
            }
        }

        private void OnDrawGizmos()
        {
            if (targeted)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position,2);
            }
        }
    }
}
