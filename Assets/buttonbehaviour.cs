using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonbehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Button;
    void Start()
    {
        Button = GameObject.Find("button");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            GameObject[] list = GameObject.FindGameObjectsWithTag("button");
            foreach(GameObject wind in list)
            {
                Destroy(wind);
                Destroy(Button);
            }
        }
    }
}
