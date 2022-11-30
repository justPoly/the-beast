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

    public static GameManager instance;

    private void Awake()
    {
        instance = this;

    }
    void Start()
    {
        isGameOver = true;
        highScore =PlayerPrefs.GetInt("HighScore", score);
    }

    void Update ()
    {
        if(isGameOver == true)
        {
            
            distance += Time.deltaTime;
            score = (int)distance;
            
            scoreText.text = "Score: " + score.ToString();
            highScoreText.text = "Score: " + highScore.ToString();
            
        }
        if(highScore<score)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore =PlayerPrefs.GetInt("HighScore", score);
            highScoreText.text = "Highest Score: " + highScore.ToString();
        }
        
    }

    public void GameOver()
    {
        isGameOver = false;
        GameOverPanel.SetActive(true);
        OnGameEnded.Raise();

    }

}

