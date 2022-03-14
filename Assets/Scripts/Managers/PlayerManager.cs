using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static event Action OnPlayerStartedGame;
    public static event Action OnPlayerEndedGame;

    private static GameObject _player;

    private void Start()
    {
       FetchPlayer();
    }

    private static void FetchPlayer()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StartGame") && !GameManager.GameStarted())
        {
            if (OnPlayerStartedGame != null)
            {
                OnPlayerStartedGame();
                return;
            }
        }
        if (other.gameObject.CompareTag("EndGame") && GameManager.GameStarted())
        {
            if (OnPlayerEndedGame != null)
            {
                OnPlayerEndedGame();
                return;
            }
        }
    }

    public static GameObject GetPlayer()
    {
        if (!_player) FetchPlayer();
        return _player;
    }
}
