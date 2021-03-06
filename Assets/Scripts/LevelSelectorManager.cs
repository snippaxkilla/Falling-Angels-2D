using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorManager : MonoBehaviour
{
    public void GoToLevel(int level)
    {
        SceneManager.LoadScene($"Level{level}");
    }

}
