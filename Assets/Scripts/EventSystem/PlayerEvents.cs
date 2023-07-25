using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{
    public class PlayerEvents
    {
        public delegate void PlayerPositionEvent(Vector3 pos);

        public PlayerPositionEvent OnUpdatePlayerPosition;
    }
}

