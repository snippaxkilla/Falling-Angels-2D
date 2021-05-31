using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TallySystem : MonoBehaviour
{
    private Text scoreText;
    private int score;

    private void Start()
    {
        scoreText = GetComponent<Text>();     
    }

    public void AddScore(int CoinValue)
    {
        score += CoinValue;
        scoreText.text = "Coins: " + score.ToString();
    }
}
