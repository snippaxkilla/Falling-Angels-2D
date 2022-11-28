using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DevilBehaviour : MonoBehaviour
{
    [SerializeField] private float delay = 2f;

    public RotateMap rotate;
    public GameObject Goal, RedPortal, BluePortal, DissapearingWall;
    public int transportTimer = 0, transportSeconds = 20;
    private Vector3 currentRedPortalPosition, currentBluePortalPosition, currentGoalPosition;
    string[] Hazards = { "Spikes", "RotatingSaw", "DeathPlane", "Lava" };

    private bool transported = false;
    public Rigidbody2D rBody;
    public bool launchpadActive = false;
    public float launchpadTimer;
    AudioManager aManage;
    public AudioSource GemCollect;
    public AudioSource DoorOpen;
    public AudioSource WindHatch;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        RedPortal = GameObject.Find("RedPortal");
        BluePortal = GameObject.Find("BluePortal");
        DissapearingWall = GameObject.Find("Dissapearingwall");
        Goal = GameObject.Find("Goal");
        aManage = GetComponent<AudioManager>();
    }
    private void Update()
    {
        if (Goal)
        {
            currentGoalPosition = Goal.transform.position;
        }

        if (RedPortal && BluePortal)
        {
            currentRedPortalPosition = RedPortal.transform.position;
            currentBluePortalPosition = BluePortal.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ResetGame();
        }

        if (transported)
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
            GemCollect.Play();
        }

        for (int i = 0; i < Hazards.Length; i++)
        {
            if (Other.gameObject.CompareTag(Hazards[i]))
            {
                Destroy(gameObject);
                ResetGame();
                
                //StartCoroutine(ResetGameDelay(delay)); 
            }
        }

        if (!transported && Other.gameObject.CompareTag("RedPortal"))
        {
            this.transform.position = currentBluePortalPosition;
            transported = true;
        }

        if (!transported && Other.gameObject.CompareTag("BluePortal"))
        {
            this.transform.position = currentRedPortalPosition;
            transported = true;
        }

        if (Other.gameObject.CompareTag("Goal"))
        {
            FindObjectOfType<LevelLoader>().StartLoadWinTransition();

            this.transform.position = Goal.transform.position;

            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            DoorOpen.Play();
        }

        if (Other.gameObject.CompareTag("Launchpad"))
        {
            launchpadActive = true;
        }

        if (Other.gameObject.CompareTag("Inverterpad"))
        {
            rotate.Speed *= -1;
        }
        if (Other.gameObject.CompareTag("Pressurepad"))
        {
            DissapearingWall.SetActive(false);
        }
    }

    private IEnumerator ResetGameDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        ResetGame();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        TallyManager.Reset();
    }
}
