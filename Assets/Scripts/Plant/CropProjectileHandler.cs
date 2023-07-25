using EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropProjectileHandler : MonoBehaviour
{
    private float damage;

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EventChannels.EnemyEvents.OnEnemyTakesDamage?.Invoke(damage);
        }
    }
} 
