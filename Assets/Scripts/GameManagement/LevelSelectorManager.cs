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

        //which level needs to have the ui added, because we don't want the system to randomly add them too all to increase performance
        LevelManager.Level = level;
        SceneManager.LoadScene($"Level{level}");
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        Timer.Instance.InitialStartLevel();
    }

    //main menu is indexed as 1
    public void GoToMainMenu() 
    {
        SceneManager.LoadScene(1);
    }
}
