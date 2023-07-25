using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{
    public class EnemyEvents
    {
        public delegate void DamageEvent(float damage);

        public DamageEvent OnEnemyDealsDamage;
        public DamageEvent OnEnemyTakesDamage;
    }
}
