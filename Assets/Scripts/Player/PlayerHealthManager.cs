using EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField]
    private float playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        EventChannels.EnemyEvents.OnEnemyDealsDamage += TakeDamage;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnDestroy()
    {
        EventChannels.EnemyEvents.OnEnemyDealsDamage -= TakeDamage;
        // Game over!
    }

    void TakeDamage(float damage)
    {
            playerHealth -= damage;
            Debug.Log($"Damage dealt {damage}");
            Debug.Log($"player health is {playerHealth}");
        if (playerHealth <= 0)
            Destroy(gameObject);
    }
}
