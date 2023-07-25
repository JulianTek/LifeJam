using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{
    public class UIEvents : MonoBehaviour
    {
        public delegate void HealthEvent(float health);
        public delegate void EnemyEvent(Enemy enemy);

        public HealthEvent OnUpdatePlayerHealthbar;
        public HealthEvent OnUpdateEnemyHealthbar;

        public EnemyEvent OnSetEnemyHealthbar;
    }
}

