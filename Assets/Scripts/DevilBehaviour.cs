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
    string[] Hazards = { "Spikes", "RotatingSaw", "DeathPlane", "Lava" };

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

        for (int i = 0; i < Hazards.Length; i++)
        {
            if (Other.gameObject.CompareTag(Hazards[i]))
            {
                ResetGame();
            }
        }

        if (!transported && Other.gameObject.CompareTag("RedPortal"))

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
            FindObjectOfType<LevelLoader>().LoadNextLevel();
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

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

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
