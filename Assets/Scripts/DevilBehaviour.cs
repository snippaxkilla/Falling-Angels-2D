using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DevilBehaviour : MonoBehaviour
{
    public RotateMap rotate;
    public GameObject RedPortal, BluePortal, DissapearingWall;
    public int transportTimer = 0, transportSeconds = 20;
    public Vector3 currentRedPortalPosition, currentBluePortalPosition;
    private bool transported = false;
    public Rigidbody2D rBody;
    public bool launchpadActive = false;
    public float launchpadTimer;

    

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        RedPortal = GameObject.Find("RedPortal");
        BluePortal = GameObject.Find("BluePortal");
        DissapearingWall = GameObject.Find("Dissapearingwall");
    }
    private void Update()
    {
        //Debug.Log(transform.position);

        if (RedPortal && BluePortal)
        {
            currentRedPortalPosition = RedPortal.transform.position;
            currentBluePortalPosition = BluePortal.transform.position;
        }

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

        if(launchpadActive == true)
        {
            launchpadTimer += Time.deltaTime * 1;
            rBody.gravityScale = -0.8f;
            if(launchpadTimer >= 2)
            {
                launchpadActive = false;
                launchpadTimer = 0;
            }

        }

        else 
        {
            rBody.gravityScale = 0.8f;
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
            var currentLevel = int.Parse(SceneManager.GetActiveScene().name.Replace("Level", ""));
            FindObjectOfType<LevelSelectorManager>().GoToLevel(currentLevel + 1);
        }

        if(Other.gameObject.CompareTag("Launchpad"))
        {
            launchpadActive = true;
        }

        if(Other.gameObject.CompareTag("Inverterpad"))
        {
            rotate.Speed = rotate.Speed * -1;
        }
        if(Other.gameObject.CompareTag("Pressurepad"))
        {
            DissapearingWall.SetActive(false);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
