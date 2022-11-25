using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempManager : MonoBehaviour
{
    [Header("GameEvents")]
    // public GameEvent OnGameEnded;
    public GameObject pan;

    public static TempManager instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
       gameObject.SetActive(true);
    //    OnGameEnded.Raise();
    }
}
