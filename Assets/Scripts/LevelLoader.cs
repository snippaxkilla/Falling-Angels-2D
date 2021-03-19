using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        //change the if to so it does this only when ontriggerenter for devil is the goal
        if (Input.GetMouseButtonDown(0)) 
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel() 
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    //delay code from running because the animtation needs to finish first, otherwise the player might die 
    IEnumerator LoadLevel(int levelIndex) 
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
