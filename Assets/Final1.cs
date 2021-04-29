using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final1 : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)&&gameObject!=null)
        {
            gameObject.SetActive(false);
        }
    }
}
