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
    [SerializeField] private StatsPanel _statsPanel;
    [SerializeField] private GameObject InformationPanel;
    public float spawnDistance = 2f;


    private void Awake()
    {
        SelectController.OnSelectedEntityChanged += HandleSelectedEntityChanged;
        HandleSelectedEntityChanged(SelectController.SelectedEntity);
        SelectController.OnDisplayingSelectionCanvas += AppendOptionsCanvasToObject;
        GameManager.OnGameStarted += SetStartGameUI;
        GameManager.OnGameEnded += SetEndGameUI;
        GameManager.OnNewElementAddedToDictionary += DisplayInformation;
    }

    private void OnDestroy()
    {
        SelectController.OnSelectedEntityChanged -= HandleSelectedEntityChanged;
        SelectController.OnDisplayingSelectionCanvas -= AppendOptionsCanvasToObject;
        GameManager.OnGameStarted -= SetStartGameUI;
        GameManager.OnGameEnded -= SetEndGameUI;
        GameManager.OnNewElementAddedToDictionary -= DisplayInformation;
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

    }

    // Faltaria ver el DESTROY del Canvas
    private void AppendOptionsCanvasToObject(Transform targetTransform)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Camera mainCam = player.GetComponentInChildren<Camera>();

        _optionsCanvas.gameObject.transform.SetParent(targetTransform, true);
        _optionsCanvas.gameObject.transform.position =
            mainCam.transform.position + mainCam.transform.forward * spawnDistance;
        _optionsCanvas.gameObject.transform.rotation = mainCam.transform.rotation;
    }

    private void DisplayInformation(Entity e)
    {
        if (!InformationPanel.activeInHierarchy)
        {
            InformationPanel.SetActive(true);
            if (e != null)
            {
                InformationPanel.GetComponentInChildren<TMP_Text>().text = $"Recogiste {e.GetKey()}";
            }
            else
            {
                InformationPanel.GetComponentInChildren<TMP_Text>().text = "Ya habias recogido eso!";
            }
            
            StartCoroutine(DisableCanvas());
        }
        
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

    private void SetStartGameUI()
    {
            _statsPanel.gameObject.SetActive(true);
            _listPanel.gameObject.SetActive(true);
            _wrongItemsListPanel.gameObject.SetActive(true);
            _wrongItemsListPanel.GetComponent<Canvas>().enabled = false;
    }

    private void SetEndGameUI()
    {
            _statsPanel.gameObject.SetActive(true);
            _listPanel.gameObject.SetActive(true);
            _wrongItemsListPanel.gameObject.SetActive(true);
            _wrongItemsListPanel.GetComponent<Canvas>().enabled = true;
            _wrongItemsListPanel.GetComponent<CheckListManager>().DisplayElapsedTimes();
            _listPanel.GetComponent<CheckListManager>().DisplayElapsedTimes();
    }
    
}
