using EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropProjectileHandler : MonoBehaviour
{
    public float damage = 1.5f;
    private float duration = 5f;
    private float timer = 0f;
    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    private void OnEnable()
    {
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= duration)
            ObjectPoolHandler.ReturnObjectToPool(gameObject);
    }

    private void OnTriggerEnter(Collider other, GameObject go)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHandler>().TakeDamage(damage, other.gameObject);
        }
    }
} 
