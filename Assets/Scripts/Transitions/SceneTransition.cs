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

        animator.SetBool("FadeOut", true);
    }

    public void OnFadeComplete()
    {
        animator.SetBool("FadeOut", false);

        notEntry = true;

        if (levelToLoad >= 2)
        {
            EndScene();
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
        Application.Quit();
    }
}
