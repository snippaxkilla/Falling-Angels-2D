using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class period : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject geyser;
    float tiem = 0;
    void Start()
    {
        //geyser = GameObject.Find("wind");
    }

    // Update is called once per frame
    void Update()
    {
         tiem += Time.deltaTime;
        
        if (tiem >= 1)
        {
            
            if (geyser.activeSelf)
            {
                
                geyser.SetActive(false);
            }
            else if (!geyser.activeSelf)
            {
                
                geyser.SetActive(true);
            }
            tiem = 0;
        }
    }
}
