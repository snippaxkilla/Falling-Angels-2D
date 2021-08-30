using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockerBehavior : MonoBehaviour
{
    [SerializeField] GameObject[] lol;

    [SerializeField] Collider2D PlayerBlocker;
    // Start is called before the first frame update
    void Start()
    {

        lol = GameObject.FindGameObjectsWithTag("Lava");
        Collider2D[] hi;
        for (int i = 0; i < lol.Length; i++)
        {
            hi = lol[i].GetComponents<Collider2D>();
            Physics2D.IgnoreCollision(hi[1], PlayerBlocker, true);
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
