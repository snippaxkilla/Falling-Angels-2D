using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavablockerbehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Collider2D player;
    [SerializeField] private Collider2D lavablocker;

    void Start()
    {
        Physics2D.IgnoreCollision(player, lavablocker, true);
        //Debug.Log(Physics2D.GetIgnoreCollision(player, lavablocker));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
