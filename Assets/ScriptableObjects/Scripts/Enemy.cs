using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Enemy", menuName = "LifeJam/Create new enemy")]
public class Enemy : ScriptableObject
{
    public Sprite sprite;
    public string EnemyName;
    public int EnemyHealth;
    public int EnemyDamage;
}
