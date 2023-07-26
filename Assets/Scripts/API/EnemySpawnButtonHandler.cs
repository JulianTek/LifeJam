using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class EnemySpawnButtonHandler : MonoBehaviour
{
    [SerializeField]
    private Enemy enemyToSpawn;

    public void SendAPICall()
    {
        StartCoroutine(APIHandler.PostEnemy(enemyToSpawn));
    }
}
