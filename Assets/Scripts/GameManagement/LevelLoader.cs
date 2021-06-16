using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator Transition;
    public float TransitionTime = 1f;

    public void LoadNextLevel() 
    {
        StartCoroutine(LoadLevel(LevelManager.Level + 1));
    }

    //delay code from running because the animtation needs to finish first, otherwise the player might die 
    IEnumerator LoadLevel(int levelIndex) 
    {
        Transition.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionTime);

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
        Transition.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionTime);

        SceneManager.LoadScene("WinScreenTransition");
    }
}
