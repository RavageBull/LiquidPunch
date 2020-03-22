using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTransition : MonoBehaviour
{
    public SceneTransition transitioner;

    public AudioSource musicTrack;

    public void TriggerMusicTrack()
    {
        musicTrack.Play();
    }

    public void TransitionScenes()
    {
        transitioner.FadeToNextLevel();
    }
}
