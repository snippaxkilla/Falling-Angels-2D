using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTimer : MonoBehaviour
{
    float timer = 0;
    public bool isTimerUsed;
    public bool TimerActive = true;
    ParticleSystem pSystem;
    AreaEffector2D areaEffector2;
    // Start is called before the first frame update
    void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
        areaEffector2 = GetComponent<AreaEffector2D>();

        pSystem.Play();
        areaEffector2.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
       if(isTimerUsed == true)
        {
            
            timer += Time.deltaTime;

            if(timer >= 2 && TimerActive == true)
            {
                timer = 0;
                TimerActive = false;
                pSystem.Stop();
                areaEffector2.enabled = false;
            }

            if(timer >= 2 && TimerActive == false)
            {
                timer = 0;
                TimerActive = true;
                pSystem.Play();
                areaEffector2.enabled = true;
            }

            Debug.Log(TimerActive);
            Debug.Log(timer);
        }


    }
}
