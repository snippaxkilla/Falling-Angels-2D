using UnityEngine;
using UnityEngine.Events;

public class WorldButton : MonoBehaviour
{
    [SerializeField] private UnityEvent onPressed;
    [SerializeField] private Sprite pressedSprite;
    private SpriteRenderer spriteRenderer;
    private bool hasBeenPressed;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (hasBeenPressed)
        {
            return;
        }
        onPressed.Invoke();
        spriteRenderer.sprite = pressedSprite;
        hasBeenPressed = true;
    }
}
