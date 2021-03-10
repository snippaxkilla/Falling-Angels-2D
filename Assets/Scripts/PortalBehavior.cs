using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehavior : MonoBehaviour
{
    public GameObject RedPortal;
    public GameObject BluePortal;

    // Start is called before the first frame update
    void Start()
    {
        RedPortal = GameObject.Find("RedPortal");
        BluePortal = GameObject.Find("BluePortal");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (RedPortal.gameObject.CompareTag("Player"))
        {
            Other.transform.position = new Vector3(0, 0, 0);
            Debug.Log("0");
        }

        if (BluePortal.gameObject.CompareTag("Player"))
        {
            Other.transform.position = new Vector3(0, 0, 0);
        }
    }
}
