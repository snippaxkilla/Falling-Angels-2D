using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindSwitchCheck : MonoBehaviour
{
    public bool Switched = true;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (timer >= 2)
            {
                Switched = !Switched;
                timer = 0;
            }

            Debug.Log(Switched);
        }
    }
}
