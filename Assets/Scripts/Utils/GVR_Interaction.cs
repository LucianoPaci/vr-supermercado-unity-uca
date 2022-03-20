using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GVR_Interaction : MonoBehaviour
{

    public Image img;
    public UnityEvent GVRClick;
    private bool gvrStatus;

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus && Input.GetButtonDown("BottomTrigger"))
        {
            GVRClick?.Invoke();
        }
    }
    public void GvrOn()
    {
        gvrStatus = true;
    }
    public void GvrOff()
    {
        gvrStatus = false;
    }
}
