using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    public Button button;
    // Start is called before the first frame update

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        button.onClick.AddListener(Task);
    }

    void Task()
    {
        spriteRenderer.sprite = spriteArray[1];
        SceneManager.LoadScene("LevelSelector");
    }
}
