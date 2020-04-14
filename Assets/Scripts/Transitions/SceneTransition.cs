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
            Debug.Log("LevelTOLoad " + levelToLoad);
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
        //ExperienceApp.End();
    }
}
