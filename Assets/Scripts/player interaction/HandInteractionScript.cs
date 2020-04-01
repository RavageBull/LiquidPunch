using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandInteractionScript : MonoBehaviour
{
    public float radius,distance;

    public LayerMask interactables;

    

    public IHandInteractable closestInteractable;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IHandInteractable temp = closestInteractable;
        
        closestInteractable = GetclosesthandInteractablesInRange();
        if (temp != closestInteractable)
        {
            temp.OnHandInteractionLoseFocus(this);
            closestInteractable.OnHandInteractionGainFocus(this);
            target = (closestInteractable as MonoBehaviour).gameObject;
        }
    }
    float DistanceFromRay(Ray ray, Vector3 point)
    {
        return Vector3.Cross(ray.direction, point - ray.origin).magnitude;
    }

    RaycastHit ClosestToRay(RaycastHit[] raycastHits,Ray ray)
    {
        RaycastHit closestHit = raycastHits[0];
        float distancefromRay = DistanceFromRay(ray,closestHit.point);
            
        foreach (RaycastHit hit in raycastHits)
        {
            if (DistanceFromRay(ray,hit.point) < distancefromRay)
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
    
    

IHandInteractable GetclosesthandInteractablesInRange()
     {
         Ray ray = new Ray(transform.position,transform.forward);
         RaycastHit[] handInteractables =  Physics.SphereCastAll(ray, radius, distance, interactables, QueryTriggerInteraction.Collide);

         //return ClosestToPoint(handInteractables, transform.position).collider.GetComponent<IHandInteractable>();
         return ClosestToRay(handInteractables, ray).collider.GetComponent<IHandInteractable>();
     }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawRay(transform.position, transform.forward * distance);
        Gizmos.DrawWireSphere(transform.position + transform.forward * distance, radius);
    }
}
