using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TallyManager
{
    public delegate void ScoreUpdatedFunc(int newScore);

    public static event ScoreUpdatedFunc ScoreUpdated;

    public static int score;

    public static void AddScore(int coinScore)
    {
        score += coinScore;
        ScoreUpdated?.Invoke(score);
    }

    public static void Reset()
    {
        score = 0;
    }
}

