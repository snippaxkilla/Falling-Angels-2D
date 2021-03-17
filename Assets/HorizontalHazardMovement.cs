using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalHazardMovement : MonoBehaviour
{
    private Vector3 leftDirectionVector, rightDirectionVector, normalDirection;
    private GameObject leftBound, rightBound;
    private bool reverse = false;
    public int sawSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        leftBound = GameObject.Find("LeftBound");
        rightBound = GameObject.Find("RightBound");

    }

    // Update is called once per frame
    void Update()
    {
        if (!reverse)
        {
            rightDirectionVector = rightBound.transform.position - this.transform.position;
            rightDirectionVector.Normalize();
            normalDirection = rightDirectionVector / sawSpeed;
            this.transform.position += normalDirection;
        }

        if(reverse)
        {
            leftDirectionVector = leftBound.transform.position - this.transform.position;
            leftDirectionVector.Normalize();
            normalDirection = leftDirectionVector / sawSpeed;
            this.transform.position += normalDirection;
        }

        Debug.Log(rightDirectionVector.x);
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("RightBound"))
        {
            reverse = true;
        }

        if(Other.gameObject.CompareTag("LeftBound"))
        {
            reverse = false;
        }
    }
}
