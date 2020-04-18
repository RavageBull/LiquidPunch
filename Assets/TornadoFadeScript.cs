using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class TornadoFadeScript : MonoBehaviour
{
    public Material lightGreyTop;
    public Material blueTop;
    public Material darkGreyTop;

    public Material midLightGrey;
    public Material midDarkGrey;
    public Material blueMid;
    
    private bool blue;
    private bool lightGrey;
    private bool darkGrey;
    
    public float bluespeed;
    public float darkGreySpeed;
    public float lightGreySpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        blue = true;
        lightGrey = true;
        darkGrey = true;

        blueTop.SetFloat("_DissolveEmissive", 0);
        blueMid.SetFloat("_DissolveEmissive", 0);
        
        lightGreyTop.SetFloat("_Dissolve", 0);
        midLightGrey.SetFloat("_Dissolve", 0);
        
        darkGreyTop.SetFloat("_Dissolve", 0);
        midDarkGrey.SetFloat("_Dissolve", 0);
        
       

    }

    // Update is called once per frame
    void Update()
    {
        if (blue)
        {
            BlueFade();
        }
        if (darkGrey)
        {
           DarkGreyFade();
        }        
        if (lightGrey)
        {
            LightGreyFade();
        }
        
    }
    
    public void LightGreyFade()
    {
        if (lightGreyTop.GetFloat("_Dissolve") < 0.72)
        {
            lightGreyTop.SetFloat("_Dissolve",lightGreyTop.GetFloat("_Dissolve")+Time.deltaTime*lightGreySpeed); 
        }
        if (midLightGrey.GetFloat("_Dissolve") < 0.5)
        {
            midLightGrey.SetFloat("_Dissolve",midLightGrey.GetFloat("_Dissolve")+Time.deltaTime*lightGreySpeed);
        }
    
        
    }

    public void DarkGreyFade()
    {
        if (darkGreyTop.GetFloat("_Dissolve") < 0.5)
        {
            darkGreyTop.SetFloat("_Dissolve",darkGreyTop.GetFloat("_Dissolve")+Time.deltaTime*darkGreySpeed); 
        }
        if (midDarkGrey.GetFloat("_Dissolve") < 0.5)
        {
            midDarkGrey.SetFloat("_Dissolve",midDarkGrey.GetFloat("_Dissolve")+Time.deltaTime*darkGreySpeed);
        }

        
    }

    public void BlueFade()
    {
        if (blueTop.GetFloat("_DissolveEmissive") < 0.3)
        {
            blueTop.SetFloat("_DissolveEmissive",blueTop.GetFloat("_DissolveEmissive")+Time.deltaTime*bluespeed); 
        }
        if (blueMid.GetFloat("_DissolveEmissive") < 0.4)
        {
            blueMid.SetFloat("_DissolveEmissive",blueMid.GetFloat("_DissolveEmissive")+Time.deltaTime*bluespeed);
        }
    }

 
    
    
    public void BlueStart()
    {
        blue = true;
    }

    public void LightGreyStart()
    {
        lightGrey = true;
    }

    public void DarkGreyStart()
    {
        darkGrey = true;
    }

}
