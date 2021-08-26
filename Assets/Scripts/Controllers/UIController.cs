using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    [SerializeField] private ListPanel _listPanel;
    [SerializeField] private ListPanel _wrongItemsListPanel;

    [SerializeField] private OptionsManager _optionsCanvas;

    private void Awake()
    {
        SelectController.OnSelectedEntityChanged += HandleSelectedEntityChanged;
        HandleSelectedEntityChanged(SelectController.SelectedEntity);
        SelectController.OnDisplayingSelectionCanvas += AppendOptionsCanvasToObject;
    }

    private void OnDestroy()
    {
        SelectController.OnSelectedEntityChanged -= HandleSelectedEntityChanged;
    }
 
    private void HandleSelectedEntityChanged(Entity entity)
    {

         if(_listPanel != null)
        {
            _listPanel.Bind(entity);
        }

         if(_wrongItemsListPanel !=null)
        {
            _wrongItemsListPanel.Bind(entity);
        }
    }

    // Faltaria ver el DESTROY del Canvas
    private void AppendOptionsCanvasToObject(List<Entity> entities, Transform targetTransform)
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var camera = player.GetComponentInChildren<Camera>();
        var playerCamera = player.GetComponentInChildren<Camera>();
        var playerPosition = player.transform.position;
        var playerRotation = player.transform.rotation;

        var gameObjectPosition = targetTransform.position;
        var gameObjectRotation = targetTransform.rotation;
        var ray = GvrPointerInputModule.CurrentRaycastResult;

        var zOffset = 5f;
        var yOffset = 11f;

        Vector3 rayCastPosition = Camera.main.ScreenToWorldPoint(ray.worldPosition);
        
        // Debug.DrawRay(rayCastPosition, Camera.main.transform.forward * 1000, Color.green);

        Vector3 screenPosition = new Vector3(ray.screenPosition.x, ray.screenPosition.y, ray.distance);

        Vector3 instantiatePosition = ray.worldPosition;



        // _optionsCanvas.gameObject.transform.SetParent(playerCamera.transform);
        _optionsCanvas.gameObject.transform.SetParent(targetTransform, true);
        // _optionsCanvas.gameObject.transform.localRotation = gameObjectRotation;
        _optionsCanvas.gameObject.transform.localPosition = screenPosition;
    }
}
