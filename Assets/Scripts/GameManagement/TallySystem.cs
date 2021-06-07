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
    }

    public void AddScore()
    {
        scoreText.text = "Gems: " + TallyManager.score.ToString();
    }
}
