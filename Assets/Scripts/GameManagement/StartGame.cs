using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite[] SpriteArray;

    public Button button;

    //getting components
    void Start()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        button.onClick.AddListener(Task);
    }


    void Task()
    {
        SpriteRenderer.sprite = SpriteArray[1];
        SceneManager.LoadScene("LevelSelector");
    }
}
