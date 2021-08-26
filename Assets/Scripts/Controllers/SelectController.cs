using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public static event Action<Entity> OnSelectedEntityChanged;
    public static Entity SelectedEntity { get; private set; } 
    public static event Action <List<Entity>> OnSelectingEntity;
    
    public static event Action<List<Entity>, Transform> OnDisplayingSelectionCanvas;

    public List<Entity> possibleEntities = new List<Entity>();

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
            var entitiesList = ray.gameObject.GetComponents<Entity>().ToList();
            Transform pointedObjectTransform = ray.gameObject.transform;
            
            possibleEntities.Clear();
            if (entitiesList.Count > 0)
            {
                possibleEntities = entitiesList;

                // TODO: TESTING!
                var entity = possibleEntities.First();
                
                
                OnSelectingEntity?.Invoke(possibleEntities);
                OnDisplayingSelectionCanvas?.Invoke(possibleEntities, pointedObjectTransform);

                if (entity)
                {
                    SelectedEntity = entity;
                    OnSelectedEntityChanged?.Invoke(entity);
                    SelectedEntity.ChangeStatus();
                }
                  
            }

            //Debug.Log("SELECT CONTROLLER" + GvrPointerInputModule.CurrentRaycastResult.gameObject.GetComponent<Entity>().gameObject.transform.parent.name);
        } 
    }

    public List<Entity> GetPossibleEntities()
    {
        return possibleEntities;
    }
}
