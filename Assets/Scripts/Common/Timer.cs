using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private static Timer _instance;

   
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _countdownTime;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        _instance = this;
    }
    public static Timer Instance()
    {
        return _instance;
    }

    public async Task StartCountdown()
    {
        while (_countdownTime > 0)
        {
            //UpdateTimerText(timeRemaining);
            Debug.Log(_countdownTime);
            await Task.Delay(1000); // Espera 1 segundo
            _countdownTime -= 1;
        }
        Debug.Log(_countdownTime);
        var timerEnd = _countdownTime <= 0;
        // UpdateTimerText(0);
    }
    public void Reset()
    {
        _countdownTime = 5f;
    }
}

