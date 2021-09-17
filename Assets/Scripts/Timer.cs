using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private static bool _tick;
    private static float _gameTimer = 0f;
    private static string _timerString;

    void Update()
    {
        if (_tick)
        {
            _gameTimer += Time.deltaTime;
            int seconds = (int) (_gameTimer % 60);
            int minutes = (int) (_gameTimer / 60) % 60;
            
            _timerString = $"{minutes:00}:{seconds:00}";
        }
        else
        {
           ResetTimer();
        }
    }

    public static void StartTimer()
    {
        _tick = true;
    }

    public static void StopTimer()
    {
        _tick = false;
    }

    public static void ResetTimer()
    {
        _gameTimer = 0f;
    }

    public static string GetCurrentTime()
    {
        return _timerString;
    }
}