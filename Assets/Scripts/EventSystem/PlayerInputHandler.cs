using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerControls controls;
    // Start is called before the first frame update
    void Start()
    {
        controls = new PlayerControls();
        controls.Enable();
    }

    private void Update()
    {
        Vector2 movementVector = controls.Player.Movement.ReadValue<Vector2>();
        EventChannels.InputEvents.OnPlayerMove?.Invoke(movementVector);
    }

    private void OnDestroy()
    {

    }
}
