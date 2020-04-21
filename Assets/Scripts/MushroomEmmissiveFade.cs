using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEmmissiveFade : MonoBehaviour
{
    public float timer = 0;

    public float fadeTime;
    private Color startColor;
    public bool fading = false;

    private Color currentColor;

    public Renderer emissiveRenderer;
    // Start is called before the first frame update
    void Start()
    {
        emissiveRenderer = GetComponent<Renderer>();
        startColor = emissiveRenderer.material.GetColor("Color_ECD9926D");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fading)
        {
            if (timer <= fadeTime)
            {
                currentColor = Color.Lerp(startColor, Color.black, timer / fadeTime);
                timer += Time.deltaTime;
            }
            emissiveRenderer.material.SetColor("Color_ECD9926D", currentColor);
        }

    }
    private void Awake()
    {
        SceneTransition sceneTransition = FindObjectOfType<SceneTransition>();

        SceneTransition.MushroomFadeEvent += FadeOut;
    }
    public void FadeOut(float timeSpan)
    {
        fading = true;
        timer = 0;
        fadeTime = timeSpan;
    }
}
