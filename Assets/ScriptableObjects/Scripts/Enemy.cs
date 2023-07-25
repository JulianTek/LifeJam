using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "LifeJam/Create new enemy")]
public class Enemy : ScriptableObject
{
    public string EnemyName;
    public float EnemyHealth;
    public float EnemyDamage;
}
