using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CartManager : MonoBehaviour
{
    private List<Entity> objectList = new List<Entity>(); 
    void Awake()
    {
        objectList = this.GetComponentsInChildren<Entity>(includeInactive: true).ToList();
        SelectController.OnSelectedEntityChanged += HandleUpdateCart;
    }

    private void OnDisable()
    {
        SelectController.OnSelectedEntityChanged -= HandleUpdateCart;
    }

    // Update is called once per frame

    void HandleUpdateCart(Entity e)
    {
       var found = objectList.Find(obj => obj.name == e.GetKey());

       if (found)
       {
            found.gameObject.SetActive(true);
           
       }
    }
}
