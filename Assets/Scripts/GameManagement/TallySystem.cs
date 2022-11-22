using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TallySystem : MonoBehaviour
{
    public Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<Text>();

        TallyManager.ScoreUpdated += UpdateScore;
    }

    private void OnDestroy()
    {
        TallyManager.ScoreUpdated -= UpdateScore;
    }

    private void UpdateScore(int newScore)
    {
        scoreText.text = "Gems: " + newScore.ToString();
    }
}
