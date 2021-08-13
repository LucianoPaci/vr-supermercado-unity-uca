using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public static event Action<Entity> OnSelectedEntityChanged;

    public static Entity SelectedEntity { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))// TODO: agregar las variantes    
        {
            var ray = GvrPointerInputModule.CurrentRaycastResult;
            var entity = ray.gameObject.GetComponent<Entity>();
            if (entity)
            {
                SelectedEntity = entity;
                OnSelectedEntityChanged?.Invoke(entity);
                SelectedEntity.ChangeStatus();
            }

            //Debug.Log("SELECT CONTROLLER" + GvrPointerInputModule.CurrentRaycastResult.gameObject.GetComponent<Entity>().gameObject.transform.parent.name);
        } 
    }
}
