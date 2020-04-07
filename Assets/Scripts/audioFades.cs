using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioFades : MonoBehaviour
{
    public AnimationCurve fadeOutCurve;
    public AnimationCurve fadeInCurve;
    public AudioMixer audioMixer;
    public float duration;
    public float timer;
    //private float startVolume;
    public string VolumeExposedName;
    public float minVolume;

    public enum FadeDirection
    {
        FadeOut,FadeIn
    }
    public bool fading;

    public FadeDirection fadeDirection;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        UpdateAudio();
    }

    void UpdateAudio()
    {
        if (fading)
        {
           // float currentVolume = 0;
           // audioMixer.GetFloat("mainVolume",out currentVolume);
            if (timer <= duration)
            {
                if (fadeDirection == FadeDirection.FadeIn)
                {
                    float v = fadeInCurve.Evaluate(timer / duration);
                    audioMixer.SetFloat(VolumeExposedName,v);

                }
                else if (fadeDirection == FadeDirection.FadeOut)
                {
                    float v = fadeOutCurve.Evaluate(timer / duration);
                    audioMixer.SetFloat(VolumeExposedName,v);
                }
                timer += Time.deltaTime;
            }
            else if (timer > duration)
            {
                if (fadeDirection == FadeDirection.FadeIn)
                {
                    audioMixer.SetFloat(VolumeExposedName,0);

                }
                else if (fadeDirection == FadeDirection.FadeOut)
                {
                    audioMixer.SetFloat(VolumeExposedName,-80);
                }

                fading = false;
                timer = 0;
            }


        }
    }
    
    public void AudioFadeIn(float time)
    {
        //audioMixer.GetFloat( VolumeExposedName,out startVolume);
        duration = time;
        timer = 0;
        fadeDirection = FadeDirection.FadeIn;
        fading = true;
        audioMixer.SetFloat(VolumeExposedName,-80);
    }
    public void AudioFadeOut(float time)
    {
        timer = 0;
        //audioMixer.GetFloat(VolumeExposedName,out startVolume);
        duration = time;
        fadeDirection = FadeDirection.FadeOut;
        fading = true;
    }
    

}
