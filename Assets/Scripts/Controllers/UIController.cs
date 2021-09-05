using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    [SerializeField] private ListPanel _listPanel;
    [SerializeField] private ListPanel _wrongItemsListPanel;

    [SerializeField] private OptionsManager _optionsCanvas;
    [SerializeField] private GameObject _optionCanvasGO;

    [SerializeField] private GameObject InformationPanel;


    private void Awake()
    {
        SelectController.OnSelectedEntityChanged += HandleSelectedEntityChanged;
        HandleSelectedEntityChanged(SelectController.SelectedEntity);
        SelectController.OnDisplayingSelectionCanvas += AppendOptionsCanvasToObject;
    }

    private void OnDestroy()
    {
        SelectController.OnSelectedEntityChanged -= HandleSelectedEntityChanged;
        SelectController.OnDisplayingSelectionCanvas -= AppendOptionsCanvasToObject;
    }



    private void HandleSelectedEntityChanged(Entity entity)
    {

        if (_listPanel != null)
        {
            _listPanel.Bind(entity);
        }

        if (_wrongItemsListPanel != null)
        {
            _wrongItemsListPanel.Bind(entity);
        }

        if (entity)
        {
            DisplayInformation(entity);
        }
        
    }

    // Faltaria ver el DESTROY del Canvas
    private void AppendOptionsCanvasToObject(Transform targetTransform)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Camera mainCam = player.GetComponentInChildren<Camera>();
        float distance = 2f;
        
        _optionsCanvas.gameObject.transform.SetParent(targetTransform, true);
        _optionsCanvas.gameObject.transform.position =
            mainCam.transform.position + mainCam.transform.forward * distance;
        _optionsCanvas.gameObject.transform.rotation = mainCam.transform.rotation;
    }

    private void DisplayInformation(Entity e)
    {
        
        InformationPanel.SetActive(true);
        InformationPanel.GetComponentInChildren<TMP_Text>().text = $"Recogiste {e.GetKey()}";
        StartCoroutine(DisableCanvas());
    }
    
    IEnumerator DisableCanvas(int seconds = 3)
    {
        yield return new WaitForSeconds(seconds);
        InformationPanel.SetActive(false);
    }

    private void Update()
    {
        if (_optionsCanvas.selectableOptionsList.Count > 0)
        {
            Debug.Log("SelectedEntity " + SelectController.SelectedEntity);
            if (_optionsCanvas.GetComponent<Canvas>().enabled && !_optionsCanvas.isLoading)
            
            {
                StartCoroutine(_optionsCanvas.DisableCanvasLateCall());
            }
            else
            {
            
                _optionsCanvas.GetComponent<Canvas>().enabled = true;
            }
        }
    }
}
