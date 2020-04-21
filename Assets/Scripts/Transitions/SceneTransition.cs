using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
//using Liminal.SDK.Core;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition instance;

    public Animator animator;

    public static event Action JellyFishleaveEvent;
    public static event Action<float> RockFadeEvent;
    public static event Action<float> MushroomFadeEvent;
    public static event Action<float> SkyFadeEvent;
    

    private int levelToLoad = 0;

    private bool notEntry = false;
    public bool endScene = false;

    public PlayableDirector aweTimeline;
    public PlayableDirector stormTimeline;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject); 
    }
    
    
    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void FadeToLevel (int levelIndex)
    {    
        levelToLoad = levelIndex;
        Debug.Log("levelIndex is "+levelIndex);

        animator.SetBool("FadeOut", true);
    }

    public void OnFadeComplete()
    {
        animator.SetBool("FadeOut", false);

        notEntry = true;

        Debug.Log("LevelLoading " + levelToLoad);

        if (levelToLoad > 1)
        {
            EndScene();
            Debug.Log("Level is at " + levelToLoad);
        }

        else
        {
            SceneManager.LoadScene(levelToLoad);
        }
        

    }

    public void PlayAweTimeline()
    {
        if(notEntry != false)
        {
            aweTimeline.Play();
        }

        else
        {
            stormTimeline.Play();
        }
    }

    public void EndScene()
    {
        OVRManager.PlatformUIConfirmQuit();
        Application.Quit();
        Debug.Log("Experience Ended");
        //ExperienceApp.End();
    }


    public void MakeJelliesLeave()
    {
        OnJellyFishleaveEvent();
    }
    public void MakeRocksFade(float timeSpan)
    {
        OnRockFadeEvent(timeSpan);
    }

    public void MakeMushroomsFade(float timeSpan)
    {
        OnMushroomFadeEvent(timeSpan);
    }
    public void MakeSkyFade(float timeSpan)
    {
        OnSkyFadeEvent(timeSpan);
    }



    public static void OnJellyFishleaveEvent()
    {
        JellyFishleaveEvent?.Invoke();
    }

    public static void OnRockFadeEvent(float timeSpan)
    {
        RockFadeEvent?.Invoke(timeSpan);
    }

    private static void OnMushroomFadeEvent(float obj)
    {
        MushroomFadeEvent?.Invoke(obj);
    }

    private static void OnSkyFadeEvent(float obj)
    {
        SkyFadeEvent?.Invoke(obj);
    }
}
