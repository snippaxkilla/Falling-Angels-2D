using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DevilBehaviour : MonoBehaviour
{
    public RotateMap rotate;
    public GameObject RedPortal, BluePortal;
    public int levelCount = 0, transportTimer = 0, transportSeconds = 20;
    public Vector3 currentRedPortalPosition, currentBluePortalPosition;
    private bool transported = false;
    

    void Start()
    {
        RedPortal = GameObject.Find("RedPortal");
        BluePortal = GameObject.Find("BluePortal");
    }
    private void Update()
    {
        Debug.Log(transform.position);

        currentRedPortalPosition = RedPortal.transform.position;
        currentBluePortalPosition = BluePortal.transform.position;

        if (Input.GetKeyDown(KeyCode.P))
        {
            ResetGame();
        }

        if(transported)
        {
            transportTimer++;
            if (transportTimer >= transportSeconds)
            {
                transported = false;
                transportTimer = 0;
            }
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

        if(!transported && Other.gameObject.CompareTag("RedPortal"))
        {
            transform.position = currentBluePortalPosition;
            transported = true;
        }

        if (!transported && Other.gameObject.CompareTag("BluePortal"))
        {
            transform.position = currentRedPortalPosition;
            transported = true;
        }

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
