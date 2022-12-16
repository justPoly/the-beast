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
    public TextMeshProUGUI finalgameoverScore;
    public bool isGameOver;
    public bool StartGame;
    // public int amtOfGameplays;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        isGameOver = false;



    }
    void Start()
    {
        highScore =PlayerPrefs.GetInt("HighScore", score);

        // amtOfGameplays = PlayerPrefs.GetInt("FIRSTTIMEOPENING", amtOfGameplays);
        // if(amtOfGameplays == 0)
        // {
        //     PlayerPrefs.SetInt("FIRSTTIMEOPENING", 1);
        // }
        
        if(PlayerPrefs.GetInt("FirstTime") == 0 && score == highScore)
        {
              PlayerPrefs.SetInt("FirstTime", 1);
              Debug.Log("Let it Be!");
        }
       
        
        
    }

    void Update ()
    {
        if(isGameOver == false )
        {
            
            distance += Time.deltaTime;
            score = (int)distance;
            scoreText.text = "Score: " + score.ToString();
            
            highScoreText.text = "Score: " + HighScore().ToString();

            finalgameoverScore.text = "High Score: " + score.ToString();
        }
        
        //  PlayerPrefs.DeleteAll();
    }

    void LateUpdate()
    {
        if (highScore > 50 && highScore == score)
        {
            Debug.Log("Hey!");
            // StartCoroutine(DistanceApplaud());
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

