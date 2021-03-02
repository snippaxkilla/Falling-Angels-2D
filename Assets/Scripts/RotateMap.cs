using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMap : MonoBehaviour
{
    public GameObject Map;
    public float Speed = 200;

    
    // Start is called before the first frame update
    void Start()
    {
        Map = GameObject.Find("Map");
    }

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