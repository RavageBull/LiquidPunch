using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class emmisivePulse : MonoBehaviour
{
    private Material pulsedmaterial;
    private Renderer pulsedrenderer;
    public Color startColor;
    public Color color;

    public Color currentColor;

    public float pulseSpeedMin;
    public float pulseSpeedMax;
    [SerializeField] private float pulseSpeed;

    public bool randomness;

    public bool syncronised;

    private float randOffset;
    private float seed;


    private Color fadeoutStartColor;
    private Color fadoutColour;
    private bool fadeingOut;
    private float fadeTime;
    private float fadeTimer;

    float xOffset = 0;

    float yOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
        pulsedrenderer = GetComponent<Renderer>();
        pulsedmaterial = pulsedrenderer.material;
        startColor = pulsedmaterial.GetColor("Color_6F9AC641");
        randOffset = Random.Range(0f, 1f);
        seed = Random.Range(0f, 1f);
        if (randomness)
        {
            pulseSpeed = Random.Range(pulseSpeedMin, pulseSpeedMax);
        }
    }

    private void Awake()
    {
        SceneTransition sceneTransition = FindObjectOfType<SceneTransition>();

        SceneTransition.RockFadeEvent += FadeOut;
    }

    // Update is called once per frame

    float map(float value, float min1, float max1, float min2, float max2)
    {
        return min2 + (value - min1) * (max2 - min2) / (max1 - min1);
    }

    public void FadeOut(float timeSpan)
    {
        fadeingOut = true;
        fadeTime = timeSpan;
        fadeTimer = 0;
        fadeoutStartColor = startColor;
        fadoutColour = color;
    }

    private void FixedUpdate()
    {
        if (fadeingOut)
        {
            if (fadeTimer <= fadeTime)
            {
                startColor = Color.Lerp(fadeoutStartColor, Color.black, fadeTimer / fadeTime);
                color = Color.Lerp(fadeoutStartColor, Color.black, fadeTimer / fadeTime);
                fadeTimer += Time.deltaTime;
            }
        }


        if (!syncronised)
        {
            xOffset = randOffset;
            yOffset = seed;
        }
        else
        {
            xOffset = 0;
            yOffset = 0;
        }

        if (randomness)
        {
            if (currentColor == startColor)
            {
                //  Random.Range(pulseSpeedMin, pulseSpeedMax);
                pulseSpeed = map(Mathf.Clamp(Mathf.PerlinNoise(seed, Time.deltaTime + xOffset), 0f, 1f), 0, 1,
                    pulseSpeedMin, pulseSpeedMax);
            }
        }

        currentColor = Color.Lerp(startColor, color, SineWave(Time.time + xOffset, pulseSpeed));

        pulsedmaterial.SetColor("Color_6F9AC641", currentColor);
        pulsedrenderer.material.SetColor("Color_6F9AC641", currentColor);
    }

    float SineWave(float x, float pulseSpeed)
    {
        float y = (Mathf.Sin(x * pulseSpeed * 2 * Mathf.PI) + 1) / 2;

        return y;
    }
}