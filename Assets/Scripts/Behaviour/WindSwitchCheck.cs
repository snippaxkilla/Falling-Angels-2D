
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindSwitchCheck : MonoBehaviour
{
    
    public bool Switched;
    public float timer = 0;
    public string WindName;
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
        if (collision.CompareTag("Player"))
        {
         

                if (timer >= 2)
                {
                    Switched = !Switched;

                    timer = 0;
                }
            

            
        }
    }
}