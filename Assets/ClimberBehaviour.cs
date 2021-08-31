using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimberBehaviour : MonoBehaviour
{
    [SerializeField] private Transform climber;
    [SerializeField] private GameObject[] points;
    private int goingTo = 0;
    private int elapsedFrames = 0;
    private  float interpolationFramesCount = 45000;
    // Start is called before the first frame update
    void Start()
    {
        points = GameObject.FindGameObjectsWithTag("ClimbPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
        climber.position = Vector3.Lerp(climber.position, points[goingTo].transform.position, interpolationRatio);
        elapsedFrames = ((int)elapsedFrames + 1) % ((int)interpolationFramesCount + 1);
        
        if (climber.position == points[goingTo].transform.position)
        {
            goingTo++;
            elapsedFrames = 0;
            if (goingTo >= points.Length)
            {
                goingTo = 0;
            }
        }
    }
}
