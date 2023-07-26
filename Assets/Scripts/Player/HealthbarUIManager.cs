using EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarUIManager : MonoBehaviour
{
    private Slider healthbar;

    private void Start()
    {
        healthbar = GetComponent<Slider>();

        EventChannels.UIEvents.OnUpdatePlayerHealthbar += UpdateHealthbar;
    }

    private void OnDestroy()
    {
        EventChannels.UIEvents.OnUpdatePlayerHealthbar -= UpdateHealthbar;
    }

    private void UpdateHealthbar(float health)
    {
        healthbar.value = health;
    }
}
