using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emmisivePulse : MonoBehaviour
{
    private Material pulsedmaterial;
    private Renderer pulsedrenderer;
    public Color startColor;
    public Color[] colors;

    public Color currentColor;

    public float pulseSpeed;

    public bool randomness;

    public bool syncronised;

    private float randOffset;
    private float seed;
    // Start is called before the first frame update
    void Start()
    {
        pulsedrenderer = GetComponent<Renderer>();
        pulsedmaterial = pulsedrenderer.material;
        startColor = pulsedmaterial.GetColor("Color_6F9AC641");
        randOffset = Random.Range(0f, 1f);
        seed = Random.Range(0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        float xOffset = 0;
        float yOffset = 0;
        if (!syncronised)
        {
            xOffset = randOffset;
            yOffset = seed;
        }

        if (!randomness)
        {
          currentColor = Color.Lerp(startColor, colors[0], SineWave(Time.time + xOffset, pulseSpeed));  
        }
        else
        {
            currentColor = Color.Lerp(startColor, colors[0], Mathf.PerlinNoise((Time.time + xOffset)  * pulseSpeed,0.1f + seed));
        }
        
        pulsedmaterial.SetColor("Color_6F9AC641",currentColor);
        pulsedrenderer.material.SetColor("Color_6F9AC641",currentColor);
    }
    float SineWave( float x, float pulseSpeed)
    {
        float y = (Mathf.Sin(x *pulseSpeed * 2 * Mathf.PI)+1)/2 ;
        
        return y;
    }
}
