using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorManager : MonoBehaviour
{
    public void GoToLevel(int level)
    {
        if (!Application.CanStreamedLevelBeLoaded($"Level{level}")) 
        {
            GoToMainMenu();
            return;
        }

        SceneManager.LoadScene($"Level{level}");
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }

    public void GoToMainMenu() 
    {
        SceneManager.LoadScene(1);
    }
}
