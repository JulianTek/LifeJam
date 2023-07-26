using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<Enemy> enemies = new List<Enemy>();
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float maxInterval;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(0f, maxInterval);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnEnemy(enemies[Random.Range(0, enemies.Count - 1)]);
            timer = Random.Range(1f, maxInterval);
        }
    }

    void SpawnEnemy(Enemy enemy)
    {
        GameObject enemyObject = ObjectPoolHandler.SpawnObject(enemyPrefab, transform.position, Quaternion.identity);
        enemyObject.GetComponent<EnemyHandler>().SetEnemy(enemy);
    }
}
