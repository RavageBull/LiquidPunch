using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingMovement : MonoBehaviour
{
    public bool square;
    public float forceMultiplier;
    public Rigidbody mainBone;
    public float pulseSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (square)
        {
            mainBone.AddForce(forceMultiplier * SquareWave(Time.time) * -mainBone.transform.up);
        }
        else
        {
            mainBone.AddForce(forceMultiplier * SineWave(Time.time) * -mainBone.transform.up);
        }
    }

    float SineWave( float x)
    {
        float y = (Mathf.Sin(x *pulseSpeed * 2 * Mathf.PI)+1)/2 ;
        
        return y;
    }

    int SquareWave(float x)
    {
        int y =
        Mathf.RoundToInt((Mathf.Sign(Mathf.Sin(x *pulseSpeed * 2 * Mathf.PI))+1)/2);
        return y;
    }
}
