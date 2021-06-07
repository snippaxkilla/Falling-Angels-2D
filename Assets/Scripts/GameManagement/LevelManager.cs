using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public static int Level;

    void Start()
    {
       if(SceneManager.sceneCount == 1)
       {
            SceneManager.LoadScene("UI", LoadSceneMode.Additive);
       }
    }


}
