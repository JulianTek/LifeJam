using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnEnemy(Enemy enemy)
    {
        GameObject enemyObject = ObjectPoolHandler.SpawnObject(enemyPrefab, transform.position, Quaternion.identity);
        enemyObject.GetComponent<EnemyHandler>().SetEnemy(enemy);
        Debug.Log(APIHandler.GetAllEnemies()[0].enemyName);
    }
}
