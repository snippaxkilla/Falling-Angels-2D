using UnityEngine;

public class ParticleRotator : MonoBehaviour
{
    [SerializeField] private float offset = 0f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private float rotateAngleMax = 45f;

    //rotates the particles lock x, y and change the z
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Sin(Time.time * rotateSpeed) * rotateAngleMax + offset);
    }
}
