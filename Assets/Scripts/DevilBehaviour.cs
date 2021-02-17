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
            resetGame();
        }
    }
    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Coin"))
        {
            Destroy(Other.gameObject);
        }

        if(Other.gameObject.CompareTag("DeathPlane"))
        {
            Debug.Log("You Died");
        }

        if(Other.gameObject.CompareTag("Goal"))
        {

            levelCount++;
            Debug.Log(levelCount);
            resetGame();

        }
    }

    void resetGame()
    {
        SceneManager.LoadScene(1+ levelCount);
        rotate.rotationDegrees = 0;

    }
}
