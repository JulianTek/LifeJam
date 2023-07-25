using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using System;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private Enemy debugEnemy;
    private bool enemyIsActive;
    private Enemy enemyData;

    private float enemyHealth;

    private bool playerIsInTrigger;
    [SerializeField]
    private float attackCooldown;
    private float timer;

    private Vector3 playerPosition;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        EventChannels.PlayerEvents.OnUpdatePlayerPosition += SetPlayerPosition;
        SetEnemy(debugEnemy);

        EventChannels.EnemyEvents.OnEnemyTakesDamage += TakeDamage;
    }

    private void SetPlayerPosition(Vector3 pos)
    {
        playerPosition = pos;
    }

    void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if enemy is not active, don't do anything
        if (!enemyIsActive)
            return;

        if (playerIsInTrigger)
        {
            timer += Time.deltaTime;
            if (timer >= attackCooldown)
            {
                EventChannels.EnemyEvents.OnEnemyDealsDamage?.Invoke(enemyData.EnemyDamage);
                timer = 0;
            }

        }

        transform.position = Vector3.MoveTowards(transform.position, playerPosition, movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        // if colliding object is the player
        if (other.gameObject.CompareTag("Player"))
            playerIsInTrigger = true;
        else if (other.gameObject.CompareTag("Projectile"))
        {
            // take damage
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            playerIsInTrigger = false;
    }

    void SetEnemy(Enemy enemy)
    {
        enemyData = enemy;
        spriteRenderer.sprite = enemy.sprite;
        enemyIsActive = true;
        enemyHealth = enemyData.EnemyHealth;
    }

    void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
            ObjectPoolHandler.ReturnObjectToPool(gameObject);
    }
}
