using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class ObjectPicker : MonoBehaviour
{
    private bool looking = false;

    GameObject player, self;

    void Start()
    {
        looking = false;
    }

    // Update is called once per frame

    #region IGvrGazeResponder implementation

    /// <summary>
    /// Called when the user is looking on a GameObject with this script,
    /// as long as it is set to an appropriate layer (see GvrGaze).
    /// </summary>
    ///
    /*
    */
    public void OnGazeEnter()
    {
        looking = true;
    }

    public void OnGazeExit()
    {
        looking = false;
    }

    public void OnGazeTrigger()
    {
    }

    #endregion
}