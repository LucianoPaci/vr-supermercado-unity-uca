﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityWithTime
{
    public string elaspedTime { get; private set; }
    public Entity entity { get; private set; }
    public EntityWithTime(string time, Entity e)
    {
        this.elaspedTime = time;
        this.entity = e;
    }

}

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static event Action<Entity> OnNewElementAddedToDictionary;
    public static Dictionary<string, EntityWithTime> TimeRecordsDictionary = new Dictionary<string, EntityWithTime>();

    private static bool _gameStarted = false;
    public static event Action OnGameStarted;
    public static event Action OnGameEnded;

    public static event Action OnDisplayMap;

    public static bool GameStarted()
    {
        return _gameStarted;
    }

    // private void Awake()
    // {
    //     PlayerManager.OnPlayerStartedGame += StartGame;
    //     PlayerManager.OnPlayerEndedGame += EndGame;
    //     SelectController.OnSelectedEntityChanged += HandleEntitiesFetched;
    //     
    //    
    // }
    
    private void OnEnable()
    {
        PlayerManager.OnPlayerStartedGame += StartGame;
        PlayerManager.OnPlayerEndedGame += EndGame;
        SelectController.OnSelectedEntityChanged += HandleEntitiesFetched;
        RebootGameState();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ButtonD") || Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        if (Input.GetKey(KeyCode.M) || Input.GetButtonDown("TopTrigger"))
        {
            OnDisplayMap?.Invoke();
        }

    }

    private void OnDisable()
    {
        PlayerManager.OnPlayerStartedGame -= StartGame;
        PlayerManager.OnPlayerEndedGame -= EndGame;
        SelectController.OnSelectedEntityChanged -= HandleEntitiesFetched;
    }


    void StartGame()
    {
        _gameStarted = true;
        Timer.StartTimer();
        TimeRecordsDictionary.Clear();
        PlayerPrefs.DeleteKey(Prefs.MAP_INVOCATIONS.ToString());
        OnGameStarted?.Invoke();
    }


    void EndGame()
    {
        _gameStarted = false;
        Timer.StopTimer();
        PlayerPrefs.SetString(Prefs.PREVIOUS_TIME.ToString(), Timer.GetCurrentTime());
        OnGameEnded?.Invoke();
        SceneManager.LoadScene("Final");
    }

    void HandleEntitiesFetched(Entity e)
    {
        if (e != null)
        {
            try
            {
                if (!TimeRecordsDictionary.ContainsKey(e.GetKey()))
                {
                    TimeRecordsDictionary.Add(e.GetKey(), new EntityWithTime(Timer.SetLap(), e));
                    // TimeRecordsDictionary.Add(e.GetKey(), new EntityWithTime(Timer.GetCurrentTime(), e));
                    OnNewElementAddedToDictionary?.Invoke(e);
                }
                else
                {
                    OnNewElementAddedToDictionary?.Invoke(null);
                }
                
            }
            catch (Exception exception)
            {
                Debug.Log($"An element with key {e.GetKey()} already exists" + exception);
                OnNewElementAddedToDictionary?.Invoke(null);
            }
        }
    }

    public static EntityWithTime GetEntityWithTime(string key)
    {
        if(TimeRecordsDictionary.TryGetValue(key, out var ewt))
        {
            return ewt;
        }

        return null;
    }

    void RebootGameState()
    {
        _gameStarted = false;
        Timer.StopTimer();
        Timer.ResetTimer();
        PlayerPrefs.DeleteKey(Prefs.MAP_INVOCATIONS.ToString());
        PlayerPrefs.DeleteKey(Prefs.RESTART_COUNT.ToString());
    }

    void RestartGame()
    {
        RebootGameState();
        PlayerPrefs.SetInt(Prefs.RESTART_COUNT.ToString(), (PlayerPrefs.GetInt(Prefs.RESTART_COUNT.ToString()) | 1));
        SceneManager.LoadScene("MainMenu");
    }
}

