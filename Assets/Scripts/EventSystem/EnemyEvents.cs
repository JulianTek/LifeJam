using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{
    public class EnemyEvents
    {
        public delegate void DamageEvent(float damage);
        public delegate void EnergyEvent(int energy);
        public delegate int GetEnergyEvent();

        public DamageEvent OnEnemyDealsDamage;
        public DamageEvent OnEnemyTakesDamage;

        public EnergyEvent OnSpendEnergy;
        public GetEnergyEvent OnGetEnergy;
    }
}
