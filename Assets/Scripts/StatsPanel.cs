using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class StatsPanel : MonoBehaviour
{
    public TMP_Text textTime;
    public TMP_Text previousTextTime;

    private void Start()
    {
        textTime = GetComponentsInChildren<TMP_Text>().ToList().Find(go => go.name == "ActualTimer");
        previousTextTime = GetComponentsInChildren<TMP_Text>().ToList().Find(go => go.name == "PreviousTimer");
    }

    void Update()
    {
        if (GameManager.GameStarted())
        {
            textTime.text = Timer.GetCurrentTime();
        }

        if (PlayerPrefs.HasKey("previousTime"))
        {
            previousTextTime.text = PlayerPrefs.GetString("previousTime");
        }
    }
    
}