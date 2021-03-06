using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMap : MonoBehaviour
{
    public GameObject Map;
    public float Speed = 200;

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
    }
}