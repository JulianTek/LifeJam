using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using System;
using Random = UnityEngine.Random;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private Enemy debugEnemy;
    private bool enemyIsActive;
    private Enemy enemyData;

    [SerializeField]
    private GameObject experienceCoinObject;

    private float enemyHealth;

    private float experienceChance;

    private bool playerIsInTrigger;
    [SerializeField]
    private float attackCooldown;
    private float timer;

    private Vector3 playerPosition;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    private void Start()
    {
        EventChannels.PlayerEvents.OnUpdatePlayerPosition += SetPlayerPosition;
        EventChannels.EnemyEvents.OnEnemyTakesDamage += TakeDamage;
        experienceChance = 85;
    }

    private void SetPlayerPosition(Vector3 pos)
    {
        playerPosition = pos;
    }

    void OnEnable()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            playerIsInTrigger = false;
    }

    public void SetEnemy(Enemy enemy)
    {
        enemyData = enemy;
        spriteRenderer.sprite = enemy.sprite;
        enemyIsActive = true;
        enemyHealth = enemyData.EnemyHealth;
        EventChannels.UIEvents.OnSetEnemyHealthbar?.Invoke(enemy);
    }

    void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            if (RollForXPDrop())
            {
                ObjectPoolHandler.SpawnObject(experienceCoinObject, transform.position, Quaternion.identity);
            }
            ObjectPoolHandler.ReturnObjectToPool(gameObject);
        }
        EventChannels.UIEvents.OnUpdateEnemyHealthbar?.Invoke(enemyHealth);

    }

    bool RollForXPDrop()
    {
        return Random.Range(0f, 100f) <= experienceChance;
    }
}
