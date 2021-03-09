using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMap : MonoBehaviour
{
    public GameObject Map;
    public float Speed = 200;
    public float Offset = 0.2f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Map.transform.Rotate(0, 0, Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Map.transform.Rotate(0, 0, -Time.deltaTime * Speed);
        }
        AccelerometerMove();
    }

    private void AccelerometerMove()
    {
        float PhoneRotationX = Input.acceleration.x;

        if (PhoneRotationX > Offset) 
        {
            Map.transform.Rotate(0, 0, -Time.deltaTime * Speed);
        }
        if (PhoneRotationX < -Offset)
        {
            Map.transform.Rotate(0, 0, Time.deltaTime * Speed);
        }
    }
}