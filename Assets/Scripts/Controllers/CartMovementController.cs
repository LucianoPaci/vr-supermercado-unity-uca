using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CartMovementController : MonoBehaviour
{
    private float Speed = 5.0f;
    private bool _isRotating = false;
    private GameObject _mainCamera;
 
    void Awake()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void LateUpdate()
    {
        // //Set your input right here to start the rotation
        if (Input.GetAxis("Vertical") != 0)
            _isRotating = !_isRotating; //Starts the rotation

        if (true) //Check if your game object is currently rotating
            SetRotate(this.gameObject, _mainCamera);
        
        // //When your child game object and your camera have the same rotation.y value, it stops the rotation
        if (Math.Abs(transform.rotation.eulerAngles.y - _mainCamera.transform.rotation.eulerAngles.y) == 0)
            _isRotating = !_isRotating;
    }  
    void SetRotate(GameObject toRotate, GameObject cam)
    {
        //You can call this function for any game object and any camera, just change the parameters when you call this function
        // transform.rotation = Quaternion.Slerp(toRotate.transform.rotation, camera.transform.rotation, Speed * Time.deltaTime);
        
        transform.rotation = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0);
    }
}
