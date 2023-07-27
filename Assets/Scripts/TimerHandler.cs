using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerHandler : MonoBehaviour
{
    private float timer;
    [SerializeField]
    private TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int timerMinutes = (int)timer / 60;
        float seconds = timer % 60;
        string timerSeconds = seconds.ToString("00");
        timerText.text = String.Format("{0}:{1}",timerMinutes, timerSeconds);
    }
}
