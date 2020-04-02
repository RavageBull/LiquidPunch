using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition instance;

    public Animator animator;

    private int levelToLoad;

    private bool notEntry = false;

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
        animator.SetBool("FadeOut", true);
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
        animator.SetBool("FadeOut", false);

        notEntry = true;
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
}
