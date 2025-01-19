using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coinCount = 0;
    public int totalCoins;
    public Text coinText;
    public Timer timer;

    void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        coinText.text = ": " + coinCount.ToString();
    }

    void Update()
    {
        coinText.text = ": " + coinCount.ToString();

        if (coinCount >= totalCoins)
        {
            if (timer != null)
            {
                timer.OnWin();
            }
        }
    }

    public void CollectCoin()
    {
        coinCount++;
    }
}
