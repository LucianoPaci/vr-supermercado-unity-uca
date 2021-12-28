using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectController : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public static event Action<Entity> OnSelectedEntityChanged;
    public static Entity SelectedEntity { get; private set; } 
    public static event Action <List<Entity>> OnSelectingEntity;
    
    public static event Action<Transform> OnDisplayingSelectionCanvas;

    public List<Entity> possibleEntities = new List<Entity>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("BottomTrigger"))// TODO: agregar las variantes    
        {
            var ray = GvrPointerInputModule.CurrentRaycastResult;
            if (ray.gameObject)
            {
                var entitiesList = ray.gameObject.GetComponents<Entity>().ToList();
                Transform pointedObjectTransform = ray.gameObject.GetComponent<Entity>()?.transform;
            
                possibleEntities.Clear();
                if (entitiesList.Count > 0)
                {
                    possibleEntities = entitiesList;
                    OnSelectingEntity?.Invoke(possibleEntities);
                    OnDisplayingSelectionCanvas?.Invoke(pointedObjectTransform);
                }
            }
            
        } 
    }

    public List<Entity> GetPossibleEntities()
    {
        return possibleEntities;
    }

    public static void GetEntity(Entity e)
    {
            SelectedEntity = e;
            OnSelectedEntityChanged?.Invoke(e);
            if (SelectedEntity)
            {
               SelectedEntity.ChangeStatus();
            }
    }
    
}
