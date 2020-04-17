using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jellyfish
{
    public class JellyFishBoundary : MonoBehaviour
    {
        public Transform PlayerTransform;
        public float minDistance;
        public float maxDistance;
        public float minHeight;
        public float turnForce;
        public bool goinDown = false;

        public enum JellyFishStates
        {
            TooLow,TooFar,TooClose
        }
        public List<JellyFishStates> currentStates;

        public Rigidbody MainBoneRigidbody;
        // Start is called before the first frame update

        // Update is called once per frame
        private void Awake()
        {
            SceneTransition sceneTransition = FindObjectOfType<SceneTransition>();

            SceneTransition.JellyFishleaveEvent += GoDownNow;
        }

        public void GoDownNow()
        {
            goinDown = true;
        }

        void FixedUpdate()
        {
            currentStates.Clear();
            
            
            if (Vector3.Distance(MainBoneRigidbody.transform.position, PlayerTransform.position) > maxDistance)
            {
                LookToward(PlayerTransform.position);
                currentStates.Add(JellyFishStates.TooFar);
            }
            else if (Vector3.Distance(MainBoneRigidbody.transform.position, PlayerTransform.position) < minDistance)
            {
                LookAway(PlayerTransform.position);
                currentStates.Add(JellyFishStates.TooClose);
            }
            
            if (goinDown)
            {
                LookDown();
            }
            else
            {
                

                if (MainBoneRigidbody.transform.position.y < minHeight)
                {
                    currentStates.Add(JellyFishStates.TooLow);
                    LookUp();
                }
            }

        }
    
        public void LookToward ( Vector3 target) 
        {
            Vector3 targetDelta = target - MainBoneRigidbody.transform.position;
            //get the angle between transform.forward and target delta
            float angleDiff = Vector3.Angle(-MainBoneRigidbody.transform.up, targetDelta);
            // get its cross product, which is the axis of rotation to
            // get from one vector to the other
            Vector3 cross = Vector3.Cross(-MainBoneRigidbody.transform.up, targetDelta);
            // apply torque along that axis according to the magnitude of the angle.
            MainBoneRigidbody.AddTorque(cross * angleDiff * turnForce);
        }
    
        public void LookAway ( Vector3 target) 
        {
 
            Vector3 targetDelta = target - MainBoneRigidbody.transform.position;
 
            //get the angle between transform.forward and target delta
            float angleDiff = Vector3.Angle(MainBoneRigidbody.transform.up, targetDelta);
 
            // get its cross product, which is the axis of rotation to
            // get from one vector to the other
            Vector3 cross = Vector3.Cross(MainBoneRigidbody.transform.up, targetDelta);
 
            // apply torque along that axis according to the magnitude of the angle.
            MainBoneRigidbody.AddTorque(cross * angleDiff * turnForce);
        }
        public void LookUp () 
        {
            //  Vector3 targetDelta = target - transform.position;
 
            //get the angle between transform.forward and target delta
            float angleDiff = Vector3.Angle(-MainBoneRigidbody.transform.up, Vector3.up);
 
            // get its cross product, which is the axis of rotation to
            // get from one vector to the other
            Vector3 cross = Vector3.Cross(-MainBoneRigidbody.transform.up, Vector3.up);
 
            // apply torque along that axis according to the magnitude of the angle.
            MainBoneRigidbody.AddTorque(cross * angleDiff * turnForce);
        }

        public void LookDown()
        {
            //  Vector3 targetDelta = target - transform.position;
 
            //get the angle between transform.forward and target delta
            float angleDiff = Vector3.Angle(MainBoneRigidbody.transform.up, Vector3.up);
 
            // get its cross product, which is the axis of rotation to
            // get from one vector to the other
            Vector3 cross = Vector3.Cross(MainBoneRigidbody.transform.up, Vector3.up);
 
            // apply torque along that axis according to the magnitude of the angle.
            MainBoneRigidbody.AddTorque(cross * angleDiff * turnForce);
        }



        private void OnDrawGizmosSelected()
        {
            minDistance = Mathf.Clamp(minDistance,0,Mathf.Infinity);
            maxDistance = Mathf.Clamp(maxDistance,minDistance,Mathf.Infinity); 
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(PlayerTransform.position,minDistance);
            Gizmos.DrawWireSphere(PlayerTransform.position,maxDistance);
        
            Gizmos.color = new Color(1,1,1,0.3f);
            Gizmos.DrawCube(new Vector3(PlayerTransform.position.x,minHeight,PlayerTransform.position.z),new Vector3(10,0.01f,10));
        }
    }
}
