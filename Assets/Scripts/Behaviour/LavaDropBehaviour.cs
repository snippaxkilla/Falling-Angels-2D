using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDropBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D Other)
    {
        if (!Other.gameObject.CompareTag("Lava"))
        {
            Destroy(gameObject);
        }
    }
}
