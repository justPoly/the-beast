using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinEvent : MonoBehaviour
{
    public static event Action OnCoinCollected;
    // Start is called before the first frame update
    public static void EventEvoked()
    {
        OnCoinCollected?.Invoke();
    }

    
}
