using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerParentHandler : MonoBehaviour
{
    [SerializeField]
    private List<Enemy> enemyDatas = new List<Enemy>();
    [SerializeField]
    private List<GameObject> enemySpawners = new List<GameObject>();
    [SerializeField]
    private float maxInterval;

    private float timer;
    private List<Enemy> enemies = new List<Enemy>();
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
            timer = Random.Range(1f, maxInterval);
            SpawnNewWave();
        }
    }

    void SpawnNewWave()
    {
        // Get list of all enemies in database
        List<EnemyDTO> enemyDTOs = APIHandler.GetAllEnemies();
        if (enemyDTOs != null && enemyDTOs.Count > 0)
        {
            foreach (EnemyDTO enemyDto in enemyDTOs)
            {
                // Get the corresponding scriptable objects and add to list
                foreach (Enemy enemy in enemyDatas)
                {
                    if (enemyDto.enemyName == enemy.EnemyName)
                        enemies.Add(enemy);
                }
            }
            // Divide amount of enemies by amount of spawners to get amount of enemies to spawn per enemy spawner
            int enemiesPerWave = enemies.Count / enemySpawners.Count;
            foreach (GameObject enemySpawner in enemySpawners)
            {
                // Spawn the enemies
                EnemySpawner enemySpawnerScript = enemySpawner.GetComponent<EnemySpawner>();
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    if (i < enemies.Count)
                    {
                        enemySpawnerScript.SpawnEnemy(enemies[i]);
                        // Remove the enemy at given index
                        enemies.RemoveAt(i);
                    }

                }
            }
            // Clear the list, in case division leaves some enemies out
            enemies.Clear();
            // Remove enemies from API db
            StartCoroutine(APIHandler.DeleteAll());
        }
    }
}
