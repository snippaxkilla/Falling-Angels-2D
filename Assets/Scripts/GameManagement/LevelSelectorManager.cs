using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorManager : MonoBehaviour
{
    public void GoToLevel(int level)
    {
        if (!Application.CanStreamedLevelBeLoaded($"Level{level}"))
        {
            GoToLevelSelector();
            return;
        }

        //which level needs to have the ui added, because we don't want the system to randomly add them too all to increase performance
        LevelManager.Level = level;
        SceneManager.LoadScene($"Scenes/Included levels/Level{level}");
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        Timer.Instance.InitialStartLevel();

        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "Level", level}
        };

        AnalyticsService.Instance.CustomData("LevelStarted", parameters);
    }

    public void GoToLevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");
    }
}
