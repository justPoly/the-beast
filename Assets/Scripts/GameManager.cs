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

    [Header("GameEvent")]
    public GameEvent OnGameEnded;
    public GameObject GameOverPanel;
    public bool isGameOver;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;

    }
    void Start()
    {
        isGameOver = true;
    }

    void Update ()
    {
        if(isGameOver == true)
        {
            
            distance += Time.deltaTime;
            score = (int)distance;
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void GameOver()
    {
        isGameOver = false;
        GameOverPanel.SetActive(true);
        OnGameEnded.Raise();

    }

}

