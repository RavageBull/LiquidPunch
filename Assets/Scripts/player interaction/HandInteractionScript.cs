using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandInteractionScript : MonoBehaviour
{
    public float radius,distance;

    public LayerMask interactables;
    public OVRInput.Button interactButton;
    public OVRInput.Controller controller;

    

    public IHandInteractable closestInteractable;
    public GameObject target;
    public Ray targetRay;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IHandInteractable temp = closestInteractable;
        
        targetRay = new Ray(transform.position,transform.forward);
        if (!OVRInput.Get(interactButton,controller))
        {
            closestInteractable = GetclosesthandInteractablesInRange(targetRay);
        }

        if (temp != closestInteractable)
        {
            temp.OnHandInteractionLoseFocus(this);
            closestInteractable.OnHandInteractionGainFocus(this);
            target = (closestInteractable as MonoBehaviour).gameObject;
        }
        
        if(OVRInput.GetDown(interactButton,controller))
        {
            if (target != null)
            {
                closestInteractable.OnHandInteractTriggerDown(this);
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
    float DistanceFromRay(Ray ray, Vector3 point)
    {
        return Vector3.Cross(ray.direction, point - ray.origin).magnitude;
    }

    RaycastHit ClosestToRay(RaycastHit[] raycastHits,Ray ray)
    {
        RaycastHit closestHit = new RaycastHit();
        float distancefromRay = Mathf.Infinity;
          
        
        foreach (RaycastHit hit in raycastHits)
        {
            if (DistanceFromRay(ray,hit.point) < distancefromRay && !hit.collider.GetComponent<IHandInteractable>().TargetedByOther(this) )
            {
                closestHit = hit;
                distancefromRay = DistanceFromRay(ray, closestHit.point);
            }
        }

        return closestHit;
    }
    RaycastHit ClosestToPoint(RaycastHit[] raycastHits,Vector3 point)
    {
        RaycastHit closestHit = raycastHits[0];
        float distancefromPoint = Vector3.Distance(closestHit.point,point);
            
        foreach (RaycastHit hit in raycastHits)
        {
            if ( Vector3.Distance(hit.point,point)  < distancefromPoint)
            {
                closestHit = hit;
                distancefromPoint = Vector3.Distance(closestHit.point,point);
            }
        }

        return closestHit;
    }
    
    

IHandInteractable GetclosesthandInteractablesInRange( Ray r)
     {
         RaycastHit[] handInteractables =  Physics.SphereCastAll(r, radius, distance, interactables, QueryTriggerInteraction.Collide);
         return ClosestToRay(handInteractables, r).collider.GetComponent<IHandInteractable>();
     }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawRay(transform.position, transform.forward * distance);
        Gizmos.DrawWireSphere(transform.position + transform.forward * distance, radius);
    }
}
