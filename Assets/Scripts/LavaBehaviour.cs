using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBehaviour : MonoBehaviour
{
    public float time = 0;
    public float endTime = 5;
    public GameObject LavaDrop;
    public Transform Lava;
    // Start is called before the first frame update
    void Start()
    {
        Lava = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= endTime)
        {
            Instantiate(LavaDrop, Lava.position, Lava.rotation);
            time = 0;
        }
    }
}
