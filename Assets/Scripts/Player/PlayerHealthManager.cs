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
        EventChannels.PlayerEvents.OnGameOver?.Invoke();
        EventChannels.EnemyEvents.OnEnemyDealsDamage -= TakeDamage;
    }

    void TakeDamage(float damage)
    {
        playerHealth -= damage;
        EventChannels.UIEvents.OnUpdatePlayerHealthbar?.Invoke(playerHealth);
        if (playerHealth <= 0)
            Destroy(gameObject);
    }
}
