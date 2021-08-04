using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour
{
    public static event Action OnPlayerStartedGame = null;
    public static event Action OnPlayerEndedGame = null;

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
