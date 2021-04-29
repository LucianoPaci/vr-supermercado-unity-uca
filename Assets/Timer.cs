using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text tiempotext;
    public Text tiempotextAnterior;
    public float tiempo = 0.0f;
    public bool tick;
    //public float seconds, minutes;
    float gameTimer=0f;
    void Update()
    {
        if (tick == true)
        {
            gameTimer += Time.deltaTime;
            int seconds = (int)(gameTimer % 60);
            int minutes = (int)(gameTimer / 60) % 60;
            //int hours = (int)(gameTimer / 3600) % 60;

            string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

            tiempotext.text = timerString;
        }
        else
        {
            tiempotext.text = "00:00";
        }
    }

    public void resettime()
    {
        tiempotext.text = "00:00";
    }
    public void saveTime()
    {
        tiempotextAnterior.text = tiempotext.text;
        tiempo = 0;
        tiempotext.text = "00:00";
    }
}
