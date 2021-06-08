using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIndHatch : MonoBehaviour
{
    
    public WindSwitchCheck switchCheck;
    public SpriteRenderer spriteRenderer;
    public Sprite closedSprite;
    public Sprite openSprite;
  
    public BoxCollider2D bCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        bCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(switchCheck.Switched == true)
        {
            spriteRenderer.sprite = openSprite;
            bCollider2D.enabled = false;
        }

        if(switchCheck.Switched == false)
        {

            spriteRenderer.sprite = closedSprite;
            bCollider2D.enabled = true;

        }

    }
}
