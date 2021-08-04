 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class ObjectPicker :  MonoBehaviour
{

    public static event Action<string> OnSelectedObject = (objectName) => { }; // This is to avoid having to do null checks everytime

    private bool looking = false;
    private float distance;
    public float minDistance = 10.0f;
    // Start is called before the first frame update

    GameObject player, self;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        self = gameObject;
        looking = false;

    }


    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, self.transform.position);

        //PickObject(distance);
        
    }

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
        //Debug.Log("OnGazeEnter > " + GvrPointerInputModule.CurrentRaycastResult.gameObject.GetComponent<NombreObjeto>().Objeto.ToString());
        String name = GvrPointerInputModule.CurrentRaycastResult.gameObject.GetComponent<NombreObjeto>().Objeto.ToString();
        OnSelectedObject(name);
        looking = true;
    }

    public void OnGazeExit()
    {
        
        looking = false;
    }

    public void OnGazeTrigger()
    {
        //if(distance <= minDistance)
        //{

        Debug.Log("OnGazeTrigger > " + GvrPointerInputModule.CurrentRaycastResult.gameObject.GetComponent<NombreObjeto>().Objeto.ToString());

        
        //}
    }


    void PickObject(float dist)
    {
        if (looking)
        {
            if(dist <= minDistance)
            {
                if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("BottomTrigger"))
                {

                    Debug.Log("Picking object...");

                    // Action Call with Object Param
                    OnSelectedObject(self.name);
                    // isChoosingObject(obj);
                    looking = false;
                }
                else
                {
                    return;
                }
            }
        }
    }

    // Testing if Event Triggers can be added by Code



    #endregion

}
