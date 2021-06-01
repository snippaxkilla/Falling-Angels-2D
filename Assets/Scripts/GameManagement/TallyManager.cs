using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TallyManager
{
    public static int score;

    public static void AddScore(int coinScore)
    {
        score += coinScore;
    }

    public static void Reset()
    {
        score = 0;
    }
}

