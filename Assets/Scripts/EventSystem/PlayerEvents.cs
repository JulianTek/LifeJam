using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{
    public class PlayerEvents
    {
        public delegate void PlayerPositionEvent(Vector3 pos);
        public delegate void ExperienceEvent(int experience);
        public delegate void PlayerEvent();

        public PlayerPositionEvent OnUpdatePlayerPosition;

        public ExperienceEvent OnAddExperience;
        public ExperienceEvent OnPlayerLevelUp;

        public PlayerEvent OnGameOver;
    }
}

