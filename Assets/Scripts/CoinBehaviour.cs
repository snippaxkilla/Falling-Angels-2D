using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
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
        spriteCountDown++;

        if (spriteCountDown <= 8)
        {
            spriteRenderer.sprite = spriteArray[0];
        }

        if (spriteCountDown >= 8 && spriteCountDown <= 16)
        {
            spriteRenderer.sprite = spriteArray[1];
        }

        if (spriteCountDown >= 16 && spriteCountDown <= 24)
        {
            spriteRenderer.sprite = spriteArray[2];
        }

        if (spriteCountDown >= 24 && spriteCountDown <= 32)
        {
            spriteRenderer.sprite = spriteArray[3];
        }

        if (spriteCountDown >= 32 && spriteCountDown <= 40)
        {
            spriteRenderer.sprite = spriteArray[4];
        }

        if (spriteCountDown >= 40 && spriteCountDown <= 48)
        {
            spriteRenderer.sprite = spriteArray[5];
        }

        if (spriteCountDown >= 48 && spriteCountDown <= 56)
        {
            spriteRenderer.sprite = spriteArray[6];
        }

        if (spriteCountDown >= 56 && spriteCountDown <= 64)
        {
            spriteRenderer.sprite = spriteArray[7];
        }

        if (spriteCountDown >= 64 && spriteCountDown <= 72)
        {
            spriteRenderer.sprite = spriteArray[8];
        }

        if (spriteCountDown >= 72 && spriteCountDown <= 80)
        {
            spriteRenderer.sprite = spriteArray[9];
        }

        if (spriteCountDown >= 80 && spriteCountDown <= 400)
        {
            spriteRenderer.sprite = spriteArray[0];
        }

        if (spriteCountDown >= 400)
        {
            spriteCountDown = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            Destroy(Other.gameObject);
        }
    }
}
