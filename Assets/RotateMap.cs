using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMap : MonoBehaviour
{
    public GameObject Map;

    public float angle = 90;
    public float RotationSpeed = 0.001f;
    public Quaternion wantedRotation;

    // Start is called before the first frame update
    void Start()
    {
        Map = GameObject.Find("Map");
        wantedRotation = Quaternion.LookRotation(Map.transform.position);
    }

    //put it inside a for loop with a delta timer to make a smooth motion out of it.
    //has to be changed that it doesn't rotate but sets it to the angle.

    // Update is called once per frame
    void Update()
    {
        

        
        
        if (Input.GetKeyDown(KeyCode.A))
        {

            //Map.transform.Rotate(0, 0, angle);
            wantedRotation = Quaternion.Euler(Vector3.forward * -angle);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Map.transform.Rotate(0, 0, 0);
            wantedRotation = Quaternion.Euler(Vector3.forward * (angle*2));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Map.transform.Rotate(0, 0, angle * 2);
            wantedRotation = Quaternion.Euler(Vector3.forward * 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Map.transform.Rotate(0, 0, -angle);
            wantedRotation = Quaternion.Euler(Vector3.forward * angle);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, wantedRotation, Time.time * RotationSpeed);
    }
}
