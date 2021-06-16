using UnityEngine;

public class RotateMap : MonoBehaviour
{
    public GameObject Map;
    public float Speed = 300f;
    public float Margin = 0.05f;
 
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

        if (Mathf.Abs(PhoneRotationX) > Margin) 
        {
            Map.transform.Rotate(0, 0, -Time.deltaTime * PhoneRotationX * Speed);
        }
    }
}