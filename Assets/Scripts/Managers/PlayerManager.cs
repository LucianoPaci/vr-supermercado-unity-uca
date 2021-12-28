using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static event Action OnPlayerStartedGame;
    public static event Action OnPlayerEndedGame;

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
}
