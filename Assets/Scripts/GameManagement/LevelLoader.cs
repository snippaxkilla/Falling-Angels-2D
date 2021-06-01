using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadNextLevel() 
    {
        StartCoroutine(LoadLevel(LevelManager.Level + 1));
    }

    //delay code from running because the animtation needs to finish first, otherwise the player might die 
    IEnumerator LoadLevel(int levelIndex) 
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        LevelManager.Level = levelIndex;
        TallyManager.Reset();
        SceneManager.LoadScene("Level" + levelIndex);
    }

    public void StartLoadWinTransition()
    {
        StartCoroutine(LoadWinTransition());
    }

    IEnumerator LoadWinTransition()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("WinScreenTransition");
    }
}
