using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using TMPro;

public class EnemyEnergyHandler : MonoBehaviour
{
    [SerializeField]
    private int energyCapacity;
    [SerializeField]
    private int energyPerSecond;
    private int currentEnergy;

    [SerializeField]
    private TextMeshProUGUI energyText;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        EventChannels.EnemyEvents.OnSpendEnergy += UseEnergy;
        EventChannels.EnemyEvents.OnGetEnergy += GetEnergy;
    }

    private void OnDestroy()
    {
        EventChannels.EnemyEvents.OnSpendEnergy -= UseEnergy;
        EventChannels.EnemyEvents.OnGetEnergy -= GetEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnergy < energyCapacity)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                currentEnergy += energyPerSecond;
                timer = 0;
            }
            energyText.text = $"Energy: {currentEnergy}";
        }
        else
        {
            timer = 0;
            energyText.text = $"Energy: {energyCapacity}";
        }
    }

    void UseEnergy(int energyToSpend)
    {
        currentEnergy -= energyToSpend;
    }

    int GetEnergy()
    {
        return currentEnergy;
    }
}
