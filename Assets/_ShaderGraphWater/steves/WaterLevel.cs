using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevel : MonoBehaviour
{

    public Material water;
    private float timer;
    public float risetime;
    public float multipler;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer < risetime)
        {
            water.SetFloat("_WaveHeight",timer/multipler);
            
        }
        
    }
}
