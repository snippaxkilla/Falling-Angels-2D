using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    private int spriteCountDown;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spriteCountDown++;

            if (spriteCountDown <= 16)
            {
                spriteRenderer.sprite = spriteArray[0];
            }

            if (spriteCountDown >= 16 && spriteCountDown <= 32)
            {
                spriteRenderer.sprite = spriteArray[1];
            }

            if (spriteCountDown >= 32 && spriteCountDown <= 48)
            {
                spriteRenderer.sprite = spriteArray[2];
            }

            if (spriteCountDown >= 48 && spriteCountDown <= 64)
            {
                spriteRenderer.sprite = spriteArray[3];
            }

            if (spriteCountDown >= 64 && spriteCountDown <= 80)
            {
                spriteRenderer.sprite = spriteArray[4];
            }
        }
    }
}
