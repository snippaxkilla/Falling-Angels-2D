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
    ParticleSystemRenderer pSystemRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
        areaEffector2 = GetComponent<AreaEffector2D>();
        pSystemRenderer = GetComponent<ParticleSystemRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerUsed == true)
        {

            timer += Time.deltaTime;

            

            if (timer >= timerOffset)
            {
                WindTimeSwitch = !WindTimeSwitch;
                timer = 0;

            }

            if (WindTimeSwitch == true)
            {

                pSystemRenderer.enabled = true;
                pSystem.Play();
                areaEffector2.enabled = true;
                
            }

            if (WindTimeSwitch == false)
            {
                pSystemRenderer.enabled = false;
                pSystem.Pause();
                areaEffector2.enabled = false;
                
            }

        }


    }
}