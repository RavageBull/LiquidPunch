using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingMovement : MonoBehaviour
{
    public float forceMultiplier;
    public Rigidbody mainBone;
    public float pulseSpeed;

    private float timingOffset;
    // Start is called before the first frame update
    void Start()
    {
        timingOffset = Random.Range(-1f, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mainBone.AddForce(forceMultiplier * SineWave(Time.time + timingOffset) * -mainBone.transform.up);
    }

    float SineWave( float x)
    {
        float y = (Mathf.Sin(x *pulseSpeed * 2 * Mathf.PI)+1)/2 ;
        
        return y;
    }


}
