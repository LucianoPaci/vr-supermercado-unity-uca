using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        PlayerManager.OnPlayerStartedGame += StartGame;
        PlayerManager.OnPlayerEndedGame += EndGame;
    }

    private void OnDisable()
    {
        PlayerManager.OnPlayerStartedGame -= StartGame;
        PlayerManager.OnPlayerEndedGame -= EndGame;
    }


    void StartGame()
    {
        Debug.Log("EMPEZAMOS!!!");
    }


    void EndGame()
    {
        Debug.Log("TERMINAMOS!!!");
    }
}
