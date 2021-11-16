using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CartManager : MonoBehaviour
{
    private GameObject MainCamera;
    private float Speed = 5.0f;
    private bool isRotating = false;
    
    private List<Entity> objectList = new List<Entity>();
   

    void Awake()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        objectList = this.GetComponentsInChildren<Entity>(includeInactive: true).ToList();
        SelectController.OnSelectedEntityChanged += HandleUpdateCart;
    }

    private void OnDisable()
    {
        SelectController.OnSelectedEntityChanged -= HandleUpdateCart;
    }

    // Update is called once per frame

    private void LateUpdate()
    {
        // //Set your input right here to start the rotation
        if (Input.GetAxis("Vertical") != 0)
            isRotating = !isRotating; //Starts the rotation
        
        
        
        if (true) //Check if your game object is currently rotating
            SetRotate(this.gameObject, MainCamera);
        
        // //When your child game object and your camera have the same rotation.y value, it stops the rotation
        if (Math.Abs(transform.rotation.eulerAngles.y - MainCamera.transform.rotation.eulerAngles.y) == 0)
            isRotating = !isRotating;
    }

    void HandleUpdateCart(Entity e)
    {
        if (e)
        {
            var found = objectList.Find(obj => obj.name == e.GetKey());

            if (found)
            {
                found.gameObject.SetActive(true);
            }
        }
    }

    void SetRotate(GameObject toRotate, GameObject camera)
    {
        //You can call this function for any game object and any camera, just change the parameters when you call this function
        // transform.rotation = Quaternion.Slerp(toRotate.transform.rotation, camera.transform.rotation, Speed * Time.deltaTime);
        
        transform.rotation = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0);
    }
}