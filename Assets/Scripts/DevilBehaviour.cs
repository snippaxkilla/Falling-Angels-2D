using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DevilBehaviour : MonoBehaviour
{

    public RotateMap rotate;
    public GameObject Goal, RedPortal, BluePortal, DissapearingWall;
    public int transportTimer = 0, transportSeconds = 20;
    public Vector3 currentRedPortalPosition, currentBluePortalPosition, currentGoalPosition;
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
        Goal = GameObject.Find("Goal");
    }
    private void Update()
    {
        currentGoalPosition = Goal.transform.position;

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
            this.transform.position = currentGoalPosition;
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
