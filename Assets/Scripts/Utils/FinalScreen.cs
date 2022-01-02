using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinalScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("ButtonD") || Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Intro");
        }
    }
}
