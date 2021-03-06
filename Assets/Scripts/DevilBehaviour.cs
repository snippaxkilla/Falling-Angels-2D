using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DevilBehaviour : MonoBehaviour
{
    public RotateMap rotate;
    public int levelCount = 0;
    


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ResetGame();
        }
    }
    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Coin"))
        {
            Destroy(Other.gameObject);
        }

     if (Other.gameObject.CompareTag("Spikes"))
        {
            ResetGame();
            Debug.Log("hit spike");
        }

        if (Other.gameObject.CompareTag("DeathPlane"))
        {
            Debug.Log("You Died");
        }

        /*if(Other.gameObject.CompareTag("RedPortal"))
        {
            transform.position = new Vector3(currentBluePortalPosition && retain velocity?)
        }*/

        /*if (Other.gameObject.CompareTag("BluePortal"))
        {
            transform.position = new Vector3(currentRedPortalPosition && retain velocity ?);
        }*/

        if (Other.gameObject.CompareTag("Goal"))
        {
            levelCount++;
            Debug.Log(levelCount);
            ResetGame();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            ResetGame();    
        }
    }

    void ResetGame()
    {
        SceneManager.LoadScene(1+ levelCount);
    }
}
