using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishBoundary : MonoBehaviour
{
    public Transform PlayerTransform;
    public float minDistance;
    public float maxDistance;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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
