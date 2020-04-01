using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jellyInteraction : MonoBehaviour , IHandInteractable
{
    public bool targeted = false;

    public GameObject tempIndicatorSphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void OnHandInteractionGainFocus(HandInteractionScript h)
    {
  
        targeted = true;
        tempIndicatorSphere.SetActive(true);
    }

    public void OnHandInteractionLoseFocus(HandInteractionScript h)
    {
        targeted = false;
        tempIndicatorSphere.SetActive(false);
    }
    

    public void OnHandInteractTriggerPull(HandInteractionScript h)
    {
       
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
