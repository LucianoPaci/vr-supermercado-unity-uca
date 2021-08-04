using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static bool _gameStarted = false;
    public static event Action OnRestart;

    public static bool GameStarted()
    {
        return _gameStarted;
    }

    private void Awake()
    {
        PlayerManager.OnPlayerStartedGame += StartGame;
        PlayerManager.OnPlayerEndedGame += EndGame;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("ButtonD") || Input.GetKeyDown(KeyCode.R))
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
    }


    void StartGame()
    {
        _gameStarted = true;
    }


    void EndGame()
    {
        _gameStarted = false;
    }

    void RestartGame()
    {
        //if (OnRestart != null)
        //{
        //    OnRestart();
        //}

        SceneManager.LoadScene("Intro");
    }

   
}
