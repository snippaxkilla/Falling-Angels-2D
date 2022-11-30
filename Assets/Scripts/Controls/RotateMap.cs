using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;

public class RotateMap : MonoBehaviour
{
    public GameObject Map;
    public float Speed = 300f;
    public float Margin = 0.05f;

    private int _previousDirection;

    //pc rotation
    private void Update()
    {
        int direction = 0;

        if (Input.GetKey(KeyCode.A))
        {
            direction += 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction -= 1;
        }

        Map.transform.Rotate(0, 0, direction * Time.deltaTime * Speed);

        if (_previousDirection != direction)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"Level", LevelManager.Level},
                {"TimeSinceLastDeath", Timer.Instance.TimeSpendInLevelThisSession},
                {"LevelRotationDirection", GetDirection(direction)}
            };

            AnalyticsService.Instance.CustomData("ComputerInputChanged", parameters);
        }

        _previousDirection = direction;

        AccelerometerMove();
    }

    //phone rotation 
    private void AccelerometerMove()
    {
        float PhoneRotationX = Input.acceleration.x;

        if (Mathf.Abs(PhoneRotationX) > Margin)
        {
            Map.transform.Rotate(0, 0, -Time.deltaTime * PhoneRotationX * Speed);

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"Level", LevelManager.Level},
                {"TimeSinceLastDeath", Timer.Instance.TimeSpendInLevelThisSession},
                {"Acceleration", PhoneRotationX}
            };

            AnalyticsService.Instance.CustomData("PhoneInputChanged", parameters);
        }
    }

    private static string GetDirection(int direction)
    {
        return direction switch
        {
            1 => "CounterClockWise",
            -1 => "ClockWise",
            _ => "StoppedRotating",
        };
    }
}