using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite[] SpriteArray;

    public Button button;

    //getting components
    async void Start()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        button.onClick.AddListener(Task);
        await UnityServices.InitializeAsync();
        Analytics.ResumeInitialization();
    }


    void Task()
    {
        SpriteRenderer.sprite = SpriteArray[1];
        SceneManager.LoadScene("LevelSelector");
    }
}
