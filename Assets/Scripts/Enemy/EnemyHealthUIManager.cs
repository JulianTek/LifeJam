using EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUIManager : MonoBehaviour
{
    private Slider healthbar;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Slider>();

        EventChannels.UIEvents.OnUpdateEnemyHealthbar += UpdateEnemyHealth;
    }

    void SetEnemyHealth(float enemyHealth)
    {
        healthbar.maxValue = enemyHealth;
    }

    void UpdateEnemyHealth(float enemyhealth)
    {
        healthbar.value = enemyhealth;
    }
}
