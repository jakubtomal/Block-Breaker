using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0f,5f)] [SerializeField] float speedOfGame = 1f;
    [SerializeField] int score = 0;
    [SerializeField] int poinPerHit = 74;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    

    // Update is called once per frame

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        if( gameStatusCount > 1 )
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            
        }
    }

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    void Update()
    {
        Time.timeScale = speedOfGame;
        
    }

    public void AddToScore()
    {
        score += poinPerHit;
        scoreText.text = score.ToString();
    }

    public void ResteGame()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
