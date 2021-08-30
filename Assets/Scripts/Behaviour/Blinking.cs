using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Blinking : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float maxBrightness = 1f;
    [SerializeField] private float maxRandomOffset = 1f;

    private float offSet;
    private Light2D light2D;

    void Awake()
    {
        light2D = GetComponent<Light2D>();
    }

    void Start()
    {
        offSet = Random.Range(0f, maxRandomOffset);
    }

    void Update()
    {
        light2D.intensity = ((Mathf.Sin(Time.time * offSet * speed) +1f ) /2f) * maxBrightness;
    }
}