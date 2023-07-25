using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{
    public static class EventChannels
    {
        public static InputEvents InputEvents = new InputEvents();
        public static PlayerEvents PlayerEvents = new PlayerEvents();
        public static EnemyEvents EnemyEvents = new EnemyEvents();
    }
}

