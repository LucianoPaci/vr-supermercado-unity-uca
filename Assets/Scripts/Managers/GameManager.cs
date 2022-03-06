using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static event Action<Entity> OnNewElementAddedToDictionary;
    public static Dictionary<string, EntityWithTime> TimeRecordsDictionary = new Dictionary<string, EntityWithTime>();

    private static bool _gameStarted = false;
    private static bool _gamePaused = false;
    public static event Action OnGameStarted;
    public static event Action OnGameEnded;

    public static event Action OnGamePaused;



    public static event Action OnDisplayMap;

    public static bool GameStarted()
    {
        return _gameStarted;
    }

    public static bool GamePaused()
    {
        return _gamePaused;
    }

    private void Awake()
    {
        PlayerPrefs.SetString("ControlsSchema", ControlSchema.TYPE_A.ToString());
        PlayerManager.OnPlayerStartedGame += StartGame;
        PlayerManager.OnPlayerEndedGame += EndGame;
        SelectController.OnSelectedEntityChanged += HandleEntitiesFetched;
        MainMenuController.OnGameResumed += PauseGame;
        RebootGameState();


    }

    void Update()
    {
        if (Input.GetButtonDown("ButtonD") || Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.M) || Input.GetButtonDown("TopTrigger"))
        {
            OnDisplayMap?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("ButtonA"))
        {
            PauseGame();
        }
    }

    

    private void OnDisable()
    {
        PlayerManager.OnPlayerStartedGame -= StartGame;
        PlayerManager.OnPlayerEndedGame -= EndGame;
        SelectController.OnSelectedEntityChanged -= HandleEntitiesFetched;
        MainMenuController.OnGameResumed -= PauseGame;
    }


    public static void PauseGame()
    {
        _gamePaused = !_gamePaused;
        Time.timeScale = _gamePaused ? 0: 1;
        OnGamePaused?.Invoke();
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

