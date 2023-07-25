using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{
    public class InputEvents
    {
        public delegate void MovementEvent(Vector2 movementVector);
        public delegate void ButtonEvent();

        public MovementEvent OnPlayerMove;

        public ButtonEvent OnPlayerInteract;
    }
}

