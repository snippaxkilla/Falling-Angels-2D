using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinElevatorManager : MonoBehaviour
{
    public void LoadNextLevel()
    {
        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }
}
