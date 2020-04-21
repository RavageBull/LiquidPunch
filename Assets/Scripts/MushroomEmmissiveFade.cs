using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomEmmissiveFade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        SceneTransition sceneTransition = FindObjectOfType<SceneTransition>();

        SceneTransition.MushroomFadeEvent += FadeOut;
    }

    public void FadeOut(float timeSpan)
    {
        Debug.Log("mushrooms should fade here when this is finished");
    }
}
