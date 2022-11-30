
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindSwitchCheck : MonoBehaviour
{
    public bool Switched;
    public float timer = 0;
    public string WindName;

    void Update()
    {
        timer += Time.deltaTime * 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (timer >2))
        {
            Switched = !Switched;
            timer = 0;
        }
    }
}