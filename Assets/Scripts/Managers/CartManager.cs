using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CartManager : MonoBehaviour
{
    
    private List<Entity> objectList = new List<Entity>();
    private  static GameObject anchor;

    void Awake()
    {
        objectList = this.GetComponentsInChildren<Entity>(includeInactive: true).ToList();
        anchor = GetComponentInChildren<AnchorElement>().gameObject;
        SelectController.OnSelectedEntityChanged += HandleUpdateCart;
    }

    private void OnDisable()
    {
        SelectController.OnSelectedEntityChanged -= HandleUpdateCart;
    }

    public static GameObject GetAnchorElement()
    {
        return anchor;
    }

    // Update is called once per frame

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
}