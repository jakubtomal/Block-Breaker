using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1);

    }

    public void LoadStartScene()
    {
        FindObjectOfType<GameStatus>().ResteGame();
        SceneManager.LoadScene(0);

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
