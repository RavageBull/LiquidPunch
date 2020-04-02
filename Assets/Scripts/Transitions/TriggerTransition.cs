using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTransition : MonoBehaviour
{
    public SceneTransition transitioner;    

    public void TransitionScenes()
    {
        transitioner.FadeToNextLevel();
    }
}
