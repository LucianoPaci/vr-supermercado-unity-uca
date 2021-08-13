using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private ListPanel _listPanel;
    [SerializeField] private ListPanel _wrongItemsListPanel;



    private void Awake()
    {
        SelectController.OnSelectedEntityChanged += HandleSelectedEntityChanged;
        HandleSelectedEntityChanged(SelectController.SelectedEntity);
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
}
