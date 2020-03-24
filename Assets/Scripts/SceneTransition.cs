using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition instance;

    public Animator animator;

    private int levelToLoad;

    public bool notEntry = false;

    public AudioSource AweTrack;

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

    public void PlayAweTrack()
    {
        if(notEntry != false)
        {
            AweTrack.Play();
        }
    }
}
