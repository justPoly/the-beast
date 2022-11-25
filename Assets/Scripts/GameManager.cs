using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float distance;
    public TextMeshProUGUI scoreText;

    [Header("GameEvent")]
    public GameEvent OnGameEnded;
    public GameObject GameOverPanel;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;

    }

    void Update ()
    {
        scoreText.text = "Score: " + distance.ToString();
        distance += Time.deltaTime;
    }

    public void GameOver()
    {
       GameOverPanel.SetActive(true);
       OnGameEnded.Raise();
    }

}

