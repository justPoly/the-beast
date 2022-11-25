using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempManager : MonoBehaviour
{
    [Header("GameEvents")]
    public GameEvent OnGameEnded;
    public GameObject pan;

    public static TempManager instance;

    private void Awake()
    {
        instance = this;

    }

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
       pan.SetActive(true);
       OnGameEnded.Raise();
    }
}
