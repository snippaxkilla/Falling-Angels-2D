using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.Play("Coin");
            TallyManager.AddScore(1);
            Debug.Log(TallyManager.score);
        }
    }
}
