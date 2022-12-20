using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinManager : MonoBehaviour
{
    public int coinCount;
    // Start is called before the first frame update
    public TextMeshProUGUI coinText;
    void Start()
    {
        coinCount = PlayerPrefs.GetInt("CoinAmount", coinCount);
        coinText.text = $"Coin: {coinCount}";
    }
    void Update()
    {
        

    }
    private void OnEnable()
    {
        CoinEvent.OnCoinCollected += IncrementCoin;
    }
    private void OnDisable()
    {
        CoinEvent.OnCoinCollected -= IncrementCoin;
    }
    public void IncrementCoin()
    {
        coinCount++;
        PlayerPrefs.SetInt("CoinAmount", coinCount);
        coinText.text = $"Coin: {coinCount}";
    }
}
