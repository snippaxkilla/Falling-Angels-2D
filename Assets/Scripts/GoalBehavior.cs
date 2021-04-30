using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    private bool closeDoor = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!closeDoor && other.gameObject.CompareTag("Player"))
        {
            GetComponent<Animator>().SetTrigger("Open");
            closeDoor = true;
        }
    }
}
