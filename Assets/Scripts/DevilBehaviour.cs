using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DevilBehaviour : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D devilBody;

    public float timer = 0;
    public bool hitLaunchPad = false;
    

    private void Start()
    {
       target = GetComponent<Transform>();
       devilBody = GetComponent<Rigidbody2D>();
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            resetGame();
        }

        if(hitLaunchPad == true)
        {
            timer += Time.deltaTime * 1;
        }

        if(hitLaunchPad == true && timer <= 3)
        {
            devilBody.velocity = Vector2.up; 
        }

    }
    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Coin"))
        {
            Destroy(Other.gameObject);
        }

        if(Other.gameObject.CompareTag("Goal"))
        {
            resetGame();
            Debug.Log("help");
        }

        if(Other.gameObject.CompareTag("LaunchPad"))
        {
            hitLaunchPad = true;
            Debug.Log("vlieg");
        }
    }

    void resetGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
