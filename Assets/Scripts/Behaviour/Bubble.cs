using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private float holdTime = 1.5f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float moveAmount = 1f;
    [SerializeField] private float maxRandomOffset = 1f;

    private float startY;
    private GameObject player;
    private float currentHoldTime;
    private bool isHoldingPlayer;
    private float offSet;

    void Start()
    {
        offSet = Random.Range(0f, maxRandomOffset);
        startY = transform.localPosition.y;
    }

    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, startY + Mathf.Sin(Time.time * offSet * speed) * moveAmount);
    }

    void LateUpdate()
    {
        if (isHoldingPlayer)
        {
            player.transform.position = transform.position;
            currentHoldTime += Time.deltaTime;

            if (currentHoldTime >= holdTime)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            player = collider.gameObject;
            isHoldingPlayer = true;
        }
    }
}
