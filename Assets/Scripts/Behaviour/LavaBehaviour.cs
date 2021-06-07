using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBehaviour : MonoBehaviour
{
    [Header("timing values")]
    private const int range = 10;
    [SerializeField] [Range(0, range)] private  float endTime = 5;
    [SerializeField] [Range(0, range)] public float time = 0;

    [Header("related objects")]
    [SerializeField] private GameObject LavaDrop;
    [SerializeField] private Transform Lava;
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
