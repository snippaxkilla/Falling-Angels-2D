using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTimer : MonoBehaviour
{
    float timer = 0;
    public float timerOffset;
    public bool isTimerUsed;
    public bool WindTimeSwitch;
    ParticleSystem pSystem;
    AreaEffector2D areaEffector2;
    // Start is called before the first frame update
    void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
        areaEffector2 = GetComponent<AreaEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if(isTimerUsed == true)
        {
            
            timer += Time.deltaTime;

            if(timer >= timerOffset)
            {
                WindTimeSwitch = !WindTimeSwitch;
            }

            if (WindTimeSwitch == false)
            {
                timer = 0;
                WindTimeSwitch = true;
                pSystem.Play();
                areaEffector2.enabled = true;
            }

            if (WindTimeSwitch == true)
            {
                timer = 0;
                WindTimeSwitch = false;
                pSystem.Stop();
                areaEffector2.enabled = false;
            }
            //Debug.Log(WindTimeSwitch);
            //Debug.Log(timer);
        }
    }
}
