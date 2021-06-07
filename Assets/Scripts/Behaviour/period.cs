using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class period : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject geyser;
    float time = 0;
    public float requiredTime =  2;
    void Start()
    {
        //geyser = GameObject.Find("wind");
    }

    // Update is called once per frame
    void Update()
    {
         time += Time.deltaTime;
        
        if (time >= requiredTime)
        {
            
            if (geyser.activeSelf)
            {
                
                geyser.SetActive(false);
            }
            else if (!geyser.activeSelf)
            {
                
                geyser.SetActive(true);
            }
            time = 0;
        }
    }
}
