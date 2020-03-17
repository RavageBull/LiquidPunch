using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Just throws objects around the tornado and gradually pulls them up into the air.
/// </summary>
public class TornadoPhysicsSystem : MonoBehaviour
{
    public float pullSpeed,rotationSpeed,heightOffset;
    private Vector3 offsetPossition;
    public AnimationCurve RotationDistanceModifierCurve;
    public AnimationCurve PullDistanceModifierCurve;
    private CapsuleCollider capsuleCollider;
    public List<TornadoEffected> tornadoEffecteds;
    
    private void Start()
    {
       // tornadoEffecteds = GetAllTornadoEffecteds();
       capsuleCollider.GetComponent<CapsuleCollider>();
       
    }

    private void FixedUpdate()
    {
        offsetPossition = transform.position + Vector3.up * heightOffset;
        foreach (TornadoEffected t in tornadoEffecteds)
        {
            Rigidbody rB = t.GetComponent<Rigidbody>();
            
            
          //  float distanceFromTornado = Vector3.Distance(rB.transform.position,transform.position);
           // float distancePercentofRadius = distanceFromTornado/capsuleCollider.radius;
            
           // float offsetRotationSpeed = rotationSpeed * RotationDistanceModifierCurve.Evaluate(distancePercentofRadius);
           // float offsetPullSpeed = pullSpeed * PullDistanceModifierCurve.Evaluate(distancePercentofRadius);
            
            
            
            //TODO maybe convert this to all AddForce and AddTorque. or Add Accelleration and Deceleration Artifically.
            
            Quaternion q = Quaternion.AngleAxis (rotationSpeed, transform.up);
            rB.MovePosition (q * (rB.transform.position - offsetPossition) + offsetPossition);
            rB.MoveRotation (rB.transform.rotation * q); 
            rB.AddForce((offsetPossition - rB.transform.position) * pullSpeed * rB.mass);
            //rB.MoveRotation();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<TornadoEffected>() != null)
        {
            tornadoEffecteds.Add(other.GetComponent<TornadoEffected>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(" Object Left = " + other.gameObject.name );
        if (other.GetComponent<TornadoEffected>() != null)
        {
            tornadoEffecteds.Remove(other.GetComponent<TornadoEffected>());
        }
    }

    public List<TornadoEffected> GetAllTornadoEffecteds()
    {
        return FindObjectsOfType<TornadoEffected>().ToList();
    }
    public Vector3 CalculateForceAroundAxis(TornadoEffected t)
    {
        Vector3 torque = new Vector3();
        return t.transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + Vector3.up * heightOffset, 0.5f);

        foreach (TornadoEffected t in tornadoEffecteds)
        {
            Rigidbody rB = t.GetComponent<Rigidbody>();
            if (rB != null)
            {
                Gizmos.DrawRay(t.transform.position,rB.velocity);
            }

        }
        
        
    }
}
