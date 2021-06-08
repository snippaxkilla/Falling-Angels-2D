
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSwitch : MonoBehaviour
{

    public bool isSwitchUsed;
    public bool WindSwitched;
    public WindSwitchCheck switchCheck;
    ParticleSystem pSystem;
    AreaEffector2D areaEffector2;
    ParticleSystemRenderer pSystemRenderer;
    

    // Start is called before the first frame update
    void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
        areaEffector2 = GetComponent<AreaEffector2D>();
        pSystemRenderer = GetComponent<ParticleSystemRenderer>();
        

        pSystem.Play();
        areaEffector2.enabled = true;

        
    }

    // Update is called once per frame
    void Update()
    {



        if (isSwitchUsed == true)
        {

            if (switchCheck.Switched == false)
            {
                pSystemRenderer.enabled = false;
                pSystem.Pause();
                areaEffector2.enabled = false;
               

                if (switchCheck.Switched == true)
                {
                    pSystemRenderer.enabled = true;
                    pSystem.Play();
                    areaEffector2.enabled = true;
                    
                }

            }


        }

    }
}