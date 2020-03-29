using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishBoundary : MonoBehaviour
{
    public Transform PlayerTransform;
    public float minDistance;
    public float maxDistance;
    public float minHeight;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerTransform.position) > maxDistance)
        {
            transform.LookAt(PlayerTransform.position);
        }
        else if (Vector3.Distance(transform.position, PlayerTransform.position) < maxDistance)

        {
           
        }
    }

    private void OnDrawGizmosSelected()
    {
        minDistance = Mathf.Clamp(minDistance,0,Mathf.Infinity);
        maxDistance = Mathf.Clamp(maxDistance,minDistance,Mathf.Infinity); 
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(PlayerTransform.position,minDistance);
        Gizmos.DrawWireSphere(PlayerTransform.position,maxDistance);
    }
}
