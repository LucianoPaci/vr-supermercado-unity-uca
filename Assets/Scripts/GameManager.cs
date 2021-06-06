using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static bool _gameStarted = false;

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
        Debug.Log("EMPEZAMOS!!!");
    }


    void EndGame()
    {
        _gameStarted = false;
        Debug.Log("TERMINAMOS!!!");
    }

   
}
