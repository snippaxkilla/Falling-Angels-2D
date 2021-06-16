using UnityEngine;
using UnityEngine.SceneManagement;

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
