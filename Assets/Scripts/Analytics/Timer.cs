using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoSingleton<Timer>
{
    private float initialLevelStartTimestamp;
    private float timeInLevel;

    public float TimeSinceInitialLevelStart => Time.unscaledTime - initialLevelStartTimestamp;
    public float TimeSpendInLevelThisSession => Time.timeSinceLevelLoad;

    public void InitialStartLevel()
    {
        initialLevelStartTimestamp = Time.unscaledTime;
    }

    //void EndLevelSession()
    //{
    //    timeInLevel = Time.timeSinceLevelLoad;
    //}


}
