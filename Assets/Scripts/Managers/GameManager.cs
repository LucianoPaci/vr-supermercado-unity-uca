using System;
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
    public static Dictionary<string, EntityWithTime> myDictionary = new Dictionary<string, EntityWithTime>();

    private static bool _gameStarted = false;
    private GameObject _player;
    public static event Action OnRestart;
    public static event Action OnGameStarted;
    public static event Action OnGameEnded;

    public static bool GameStarted()
    {
        return _gameStarted;
    }

    private void Awake()
    {
        PlayerManager.OnPlayerStartedGame += StartGame;
        PlayerManager.OnPlayerEndedGame += EndGame;
        SelectController.OnSelectedEntityChanged += HandleEntitiesFetched;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ButtonD") || Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        PrintDictionary();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        PlayerManager.OnPlayerStartedGame -= StartGame;
        PlayerManager.OnPlayerEndedGame -= EndGame;
        SelectController.OnSelectedEntityChanged -= HandleEntitiesFetched;
    }

    void OnLoadPlayer()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }


    void StartGame()
    {
        _gameStarted = true;
        Timer.StartTimer();
        myDictionary.Clear();
        OnGameStarted?.Invoke();
    }


    void EndGame()
    {
        _gameStarted = false;
        Timer.StopTimer();
        PlayerPrefs.SetString("previousTime", Timer.GetCurrentTime());
        OnGameEnded?.Invoke();
    }

    void HandleEntitiesFetched(Entity e)
    {
        if (e != null)
        {
            try
            {
                if (!myDictionary.ContainsKey(e.GetKey()))
                {
                    myDictionary.Add(e.GetKey(), new EntityWithTime(Timer.SetLap(), e));
                    // myDictionary.Add(e.GetKey(), new EntityWithTime(Timer.GetCurrentTime(), e));
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
        if(myDictionary.TryGetValue(key, out var ewt))
        {
            return ewt;
        }

        return null;
    }

    void RestartGame()
    {
        //if (OnRestart != null)
        //{
        //    OnRestart();
        //}

        Timer.StopTimer();
        Timer.ResetTimer();
        SceneManager.LoadScene("Intro");
    }

    void PrintDictionary()
    {
        foreach (var pair in myDictionary)
        {
            Debug.Log("Key: " + pair.Key + " Value: " + pair.Value.elaspedTime);
        }
    }
}

