using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class HandInteractionScript : MonoBehaviour
{
    public float radius,distance;

    public LayerMask interactables;
    public OVRInput.Button interactButton;
    public OVRInput.Controller controller;

    
    IHandInteractable temp;
    public IHandInteractable closestInteractable;
    public GameObject target;
    public Ray targetRay;
    private AudioSource jellyBloop;

    // Start is called before the first frame update
    void Start()
    {
        jellyBloop = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        targetRay = new Ray(transform.position,transform.forward);
        if (!OVRInput.Get(interactButton,controller))
        {
            
           // closestInteractable = GetclosesthandInteractablesInRange(targetRay);
           
           RaycastHit hit;
           bool colided = Physics.SphereCast(targetRay, radius, out hit, distance, interactables, QueryTriggerInteraction.Collide);

         
           if (colided && hit.collider.gameObject.GetComponent<IHandInteractable>() != null)
           {
               IHandInteractable tempIhand = hit.collider.gameObject.GetComponent<IHandInteractable>();

               if (!tempIhand.TargetedByOther(this))
               {
                   closestInteractable = hit.collider.gameObject.GetComponent<IHandInteractable>();
               }
               else
               {
                   closestInteractable = null;
               }
           }
           else
           {
               closestInteractable = null;
           }
        }

        if (temp != closestInteractable)
        {
            if (temp != null)
            {
              temp.OnHandInteractionLoseFocus(this);  
            }

            if (closestInteractable != null)
            {
                closestInteractable.OnHandInteractionGainFocus(this);
                target = (closestInteractable as MonoBehaviour).gameObject;
            }
            temp = closestInteractable;
        }
        
        if(OVRInput.GetDown(interactButton,controller))
        {
            if (target != null)
            {
                closestInteractable.OnHandInteractTriggerDown(this);
                if (!jellyBloop.isPlaying)
                {
                    jellyBloop.pitch = Random.Range(0.8f, 1.3f);
                    jellyBloop.Play();
                }

            }
        }
        if(OVRInput.GetUp(interactButton,controller))
        {
            if (target != null)
            {
                closestInteractable.OnHandInteractTriggerUp(this);
            }
        } 
        if(OVRInput.Get(interactButton,controller))
        {
            if (target != null)
            {
                closestInteractable.OnHandInteractTrigger(this);
            }
        }
        
        
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawRay(transform.position, transform.forward * distance);
        Gizmos.DrawWireSphere(transform.position + transform.forward * distance, radius);
    }
}
