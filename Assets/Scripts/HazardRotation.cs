using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardRotation : MonoBehaviour
{
    public GameObject RotatingHazard;
    public float Speed = 160;
    // Start is called before the first frame update
    void Start()
    {
        RotatingHazard = GameObject.Find("RotatingHazard");
    }

    // Update is called once per frame
    void Update()
    {
        RotatingHazard.transform.Rotate(0, 0, Time.deltaTime * Speed);
    }
}
