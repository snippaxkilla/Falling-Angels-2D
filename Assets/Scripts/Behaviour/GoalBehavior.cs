using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    private bool closeDoor = false;

    Animator g_Animator;

    public void Start()
    {
        g_Animator = gameObject.GetComponent<Animator>();
    }

    //check if player hits door and activates animator trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!closeDoor && other.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.Play("Goal");
            g_Animator.SetTrigger("Open");
            closeDoor = true;
        }
    }
}
