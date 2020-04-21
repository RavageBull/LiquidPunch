using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxFade : MonoBehaviour
{
    public float timer = 0;

    public float fadeTime;
    private Color startColor;
    public bool fading = false;
    private Color currentColor;

    // Start is called before the first frame update
    void Start()
    {
        
        startColor = RenderSettings.skybox.GetColor("_Tint");

        //startColor = skybox.material.GetColor("_Tint");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fading)
        {
            if (timer <= fadeTime)
            {
                currentColor = Color.Lerp(startColor, new Color(0.1f,0.1f,0.1f), timer / fadeTime);
                timer += Time.deltaTime;
            }
            RenderSettings.skybox.SetColor("_Tint", currentColor);
        }

    }
    private void Awake()
    {
        SceneTransition sceneTransition = FindObjectOfType<SceneTransition>();

        SceneTransition.SkyFadeEvent += FadeOut;
    }

    private void OnDestroy()
    {
        RenderSettings.skybox.SetColor("_Tint", startColor);    }

    public void FadeOut(float timeSpan)
    {
        fading = true;
        timer = 0;
        fadeTime = timeSpan;
    }
}
