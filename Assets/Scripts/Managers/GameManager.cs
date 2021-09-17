using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static bool _gameStarted = false;
    private GameObject _player;
    public static event Action OnRestart;
    public static event Action OnGameStarted;
    public static event Action OnGameEnded;

    public List<Entity> fetchedEntities = new List<Entity>();
    public List<string> fetchedEntitiesTime = new List<string>();
    public static Dictionary<Entity, string> fetchedEntitiesWithTime = new Dictionary<Entity, string>();

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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ButtonD") || Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
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
        OnGameStarted?.Invoke();
    }


    void EndGame()
    {
        _gameStarted = false;
        Timer.StopTimer();
        OnGameEnded?.Invoke();
    }

    void HandleEntitiesFetched(Entity e)
    {
        if (e)
        {
            // try
            // {
            //     fetchedEntitiesWithTime.Add(e, Timer.GetCurrentTime());
            // }
            // catch (Exception exception)
            // {
            //     Debug.Log($"An element with key {e} already exists");
            //     throw;
            // }
            fetchedEntitiesTime.Add(Timer.GetCurrentTime());
            fetchedEntities.Add(e);
        }
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

   
}

