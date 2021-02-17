using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMap : MonoBehaviour
{
    public GameObject Map;

    /* don't delete!!!!!!!!!!
    public float angle = 90;
    public float RotationSpeed = 0.01f;
    public Quaternion wantedRotation;*/
    public Transform target;
    public float rotateTime = 2.0f;
    public float rotateDegrees = 90.0f;
    private bool rotating = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Map = GameObject.Find("Map");
        /* don't delete!!!!!!!!!!
        wantedRotation = Quaternion.LookRotation(Map.transform.position);
        */
    }

    /* don't delete!!!!!!!!!!
     //Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        //if (timer > waitTime)
        //{
        //    visualTime = timer;

        //    // Remove the recorded 2 seconds.
        //    timer = timer - waitTime;
        //}

        if (Input.GetKeyDown(KeyCode.A))
        {
            wantedRotation = Quaternion.Euler(Vector3.forward * -angle);
            //for (int i = 0; i < 90; i++)
            //{
            //    Map.transform.Rotate(0, 0, i);
            //}
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            wantedRotation = Quaternion.Euler(Vector3.forward * (angle * 2));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            wantedRotation = Quaternion.Euler(Vector3.forward * 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            wantedRotation = Quaternion.Euler(Vector3.forward * angle);
        }
        transform.rotation = Quaternion.Lerp(Map.transform.rotation, wantedRotation, RotationSpeed);

    }*/




        void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && !rotating)
        {
            StartCoroutine(Rotate(transform, target, Vector3.forward, rotateDegrees, rotateTime));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !rotating)
        {
            StartCoroutine(Rotate(transform, target, Vector3.forward, -rotateDegrees, rotateTime));
        }
    }

    private IEnumerator Rotate(Transform camTransform, Transform targetTransform, Vector3 rotateAxis, float degrees, float totalTime)
    {
        if (rotating)
            yield return null;
        rotating = true;

        Quaternion startRotation = camTransform.rotation;
        Vector3 startPosition = camTransform.position;
        // Get end position;
        transform.RotateAround(targetTransform.position, rotateAxis, degrees);
        Quaternion endRotation = camTransform.rotation;
        Vector3 endPosition = camTransform.position;
        camTransform.rotation = startRotation;
        camTransform.position = startPosition;

        float rate = degrees / totalTime;
        //Start Rotate
        for (float i = 0.0f; Mathf.Abs(i) < Mathf.Abs(degrees); i += Time.deltaTime * rate)
        {
            camTransform.RotateAround(targetTransform.position, rotateAxis, Time.deltaTime * rate);
            yield return null;
        }

        camTransform.rotation = endRotation;
        camTransform.position = endPosition;
        rotating = false;
    }
}