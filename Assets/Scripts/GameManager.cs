using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float distance;
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    [Header("GameEvent")]
    public GameEvent OnGameEnded;
  
    public GameObject GameOverPanel;
    public int highScore;
    public bool isGameOver;
    public bool StartGame;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        isGameOver = false;


    }
    void Start()
    {
        highScore =PlayerPrefs.GetInt("HighScore", score);

    }

    void Update ()
    {
        if(isGameOver == false)
        {
            
            distance += Time.deltaTime;
            score = (int)distance;
            scoreText.text = "Score: " + score.ToString();
            
            highScoreText.text = "High Score: " + HighScore().ToString();

            
        }
        
        
    }
    public int HighScore()
    {
        if(highScore<score)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore =PlayerPrefs.GetInt("HighScore", score);
            
            
        }
        if(highScore == 0)
        {
            highScoreText.gameObject.SetActive(false);
        }
        return highScore;
    }
    public void GameOver()
    {
        isGameOver = true;
        GameOverPanel.SetActive(true);
        OnGameEnded.Raise();
        //
        
        PlayerMovement.instance.speed = 0;
        

    }
    


}

