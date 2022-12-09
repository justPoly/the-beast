using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class CoinEvent
{
    public static event Action OnCoinCollected;
    // Start is called before the first frame update
    public static void EventEvoked()
    {
        OnCoinCollected?.Invoke();
        AudioManager.instance.PlayOneShot("Coin");
    }

    
}
