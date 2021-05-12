using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static Action OnPlayerStartedGame = null;
    public static Action OnPlayerEndedGame = null;
    private bool _gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StartGame") && !_gameStarted)
        {
            if (OnPlayerStartedGame != null)
            {
                _gameStarted = true;
                OnPlayerStartedGame();
                return;
            }
        }
        if (other.gameObject.CompareTag("EndGame") && _gameStarted)
        {
            if (OnPlayerEndedGame != null)
            {
                _gameStarted = false;
                OnPlayerEndedGame();
                return;
            }
        }
    }
}
