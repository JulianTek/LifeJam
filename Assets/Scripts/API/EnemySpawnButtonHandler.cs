using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using EventSystem;
using TMPro;

public class EnemySpawnButtonHandler : MonoBehaviour
{
    [SerializeField]
    private Enemy enemyToSpawn;
    [SerializeField]
    private int energyCost;
    [SerializeField]
    private TextMeshProUGUI energyText;
    [SerializeField]
    private int amountOfEnemies;

    public void SendAPICall()
    {
        if (EventChannels.EnemyEvents.OnGetEnergy?.Invoke() >= energyCost * amountOfEnemies)
        {
            energyText.color = Color.white;
            for (int i = 0; i < amountOfEnemies; i++)
            {
                StartCoroutine(APIHandler.PostEnemy(enemyToSpawn));
                EventChannels.EnemyEvents.OnSpendEnergy?.Invoke(energyCost);
            }
        }
        else
        {
            energyText.color = Color.red;
        }
    }
}
