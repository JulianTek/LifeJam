using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyDTO
{
    public EnemyDTO(string enemyName, int enemyHealth, int enemyDamage)
    {
        this.enemyName = enemyName;
        this.enemyHealth = enemyHealth;
        this.enemyDamage = enemyDamage;
    }

    public string enemyName { get; set; }
    public int enemyHealth { get; set; }
    public int enemyDamage { get; set; }
}
