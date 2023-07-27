using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

public class ExperienceCoinHandler : MonoBehaviour
{
    [SerializeField]
    private int experienceGained;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventChannels.PlayerEvents.OnAddExperience(experienceGained);
            ObjectPoolHandler.ReturnObjectToPool(gameObject);
        }
    }
}
