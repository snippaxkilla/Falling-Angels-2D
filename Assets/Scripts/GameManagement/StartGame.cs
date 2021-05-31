using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(Task);
    }

    void Task()
    {
        SceneManager.LoadScene("LevelSelector");
    }
}
