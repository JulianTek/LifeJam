using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private void Start()
    {
        EventChannels.InputEvents.OnPlayerMove += Move;
        rb = GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {
        EventChannels.InputEvents.OnPlayerMove -= Move;
    }

    private void Move(Vector2 movementVector)
    {
        rb.MovePosition(rb.position + new Vector3(movementVector.x, 0, movementVector.y) * Time.deltaTime);
    }
}
