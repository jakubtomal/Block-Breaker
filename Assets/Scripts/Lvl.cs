using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl : MonoBehaviour
{

    [SerializeField] int breakAbleBlocks;
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        breakAbleBlocks++;
    }

    public void BlockDestroyed()
    {
        breakAbleBlocks--;
        if(breakAbleBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
