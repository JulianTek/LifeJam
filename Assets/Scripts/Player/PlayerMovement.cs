using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float movementSpeed;
    private void Start()
    {
        EventChannels.InputEvents.OnPlayerMove += Move;
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnDestroy()
    {
        EventChannels.InputEvents.OnPlayerMove -= Move;
    }

    private void Move(Vector2 movementVector)
    {
        rb.MovePosition(rb.position + new Vector3(movementVector.x, 0, movementVector.y) * Time.deltaTime * movementSpeed);
        spriteRenderer.flipX = movementVector.x < 0;
        EventChannels.PlayerEvents.OnUpdatePlayerPosition?.Invoke(gameObject.transform.position);
    }
}
