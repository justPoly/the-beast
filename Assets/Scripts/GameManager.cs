using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float distance;
    public TextMeshProUGUI scoreText;
    void Update ()
    {
        scoreText.text = "Score: " + distance.ToString();
        distance += Time.deltaTime;
     }

}

