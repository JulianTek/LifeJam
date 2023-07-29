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

        controls.Player.UseItem.performed += Interact;
        controls.Player.SwitchCrops.performed += SwitchCrops;
    }

    private void OnDestroy()
    {
        controls.Player.UseItem.performed += Interact;
    }


    void SwitchCrops(InputAction.CallbackContext ctx)
    {
        EventChannels.InputEvents.OnPlayerSwitchCrops?.Invoke(controls.Player.SwitchCrops.ReadValue<Vector2>().y);
    }

    private void Update()
    {
        Vector2 movementVector = controls.Player.Movement.ReadValue<Vector2>();
        if (movementVector != Vector2.zero)
            EventChannels.InputEvents.OnPlayerMove?.Invoke(movementVector);
    }

    private void Interact(InputAction.CallbackContext ctx)
    {
        EventChannels.InputEvents.OnPlayerInteract?.Invoke();
    }
}
