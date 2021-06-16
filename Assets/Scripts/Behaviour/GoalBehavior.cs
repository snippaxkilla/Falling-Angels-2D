using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    private bool closeDoor = false;

    Animator g_Animator;

    public void Start()
    {
        g_Animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!closeDoor && other.gameObject.CompareTag("Player"))
        {
            g_Animator.SetTrigger("Open");
            closeDoor = true;
        }
    }
}
