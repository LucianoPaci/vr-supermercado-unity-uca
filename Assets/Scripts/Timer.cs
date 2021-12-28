using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private static bool _tick;
    private static float _gameTimer = 0f;
    private static string _timerString;
    private static float _lastLap = 0f;

    void Update()
    {
        if (_tick)
        {
            _gameTimer += Time.deltaTime;
            _timerString = TimeToString(_gameTimer);
        }
        else
        {
            ResetTimer();
        }
    }

    public static string TimeToString(float Time)
    {
        int seconds = (int) (Time % 60);
        int minutes = (int) (Time / 60) % 60;
        
        return  $"{minutes:00}:{seconds:00}";
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

     public static string SetLap()
     {
         if (_lastLap == 0f)
         {
             _lastLap = _gameTimer;
         }
         else
         {
             _lastLap = _gameTimer - _lastLap;
         }

         return TimeToString(_lastLap) ;
     }
}