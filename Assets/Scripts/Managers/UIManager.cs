using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ListPanel _listPanel;
    [SerializeField] private ListPanel _wrongItemsListPanel;

    [SerializeField] private OptionsManager _optionsCanvas;
    [SerializeField] private StatsPanel _statsPanel;
    [SerializeField] private GameObject InformationPanel;

    [SerializeField] private GameObject _MinimapCanvas;
    
    private List<GameObject> mainUIPanels = new List<GameObject>();
    
    public float spawnDistance = 2f;


    private void Awake()
    {
        SelectController.OnSelectedEntityChanged += HandleSelectedEntityChanged;
        HandleSelectedEntityChanged(SelectController.SelectedEntity);
        SelectController.OnDisplayingSelectionCanvas += AppendOptionsCanvasToObject;
        GameManager.OnGameStarted += SetStartGameUI;
        GameManager.OnGameEnded += SetEndGameUI;
        GameManager.OnNewElementAddedToDictionary += DisplayInformation;
        GameManager.OnDisplayMap += ShowMap;
        
        mainUIPanels.Add(_statsPanel.gameObject);
        mainUIPanels.Add(_listPanel.gameObject);
        mainUIPanels.Add(_wrongItemsListPanel.gameObject);
        
        
    }

    private void OnDestroy()
    {
        SelectController.OnSelectedEntityChanged -= HandleSelectedEntityChanged;
        SelectController.OnDisplayingSelectionCanvas -= AppendOptionsCanvasToObject;
        GameManager.OnGameStarted -= SetStartGameUI;
        GameManager.OnGameEnded -= SetEndGameUI;
        GameManager.OnNewElementAddedToDictionary -= DisplayInformation;
        GameManager.OnDisplayMap -= ShowMap;
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

   
    private void AppendOptionsCanvasToObject(Transform targetTransform)
    {
        GameObject player = PlayerManager.GetPlayer();
        Camera mainCam = player.GetComponentInChildren<Camera>();

       GameObject anchor = targetTransform.GetComponentInChildren<AnchorElement>().gameObject;
        
        _optionsCanvas.gameObject.transform.SetParent(anchor.transform, true);
        _optionsCanvas.gameObject.transform.position = anchor.transform.position + mainCam.transform.forward * spawnDistance;
        _optionsCanvas.gameObject.transform.rotation = mainCam.transform.rotation;
        
        // _optionsCanvas.gameObject.transform.SetParent(targetTransform, true);
        // _optionsCanvas.gameObject.transform.position = mainCam.transform.position + mainCam.transform.forward * spawnDistance;
        // _optionsCanvas.gameObject.transform.rotation = mainCam.transform.rotation;
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
            
            StartCoroutine(AsyncHide(InformationPanel, 2));
        }
        
    }
    
    IEnumerator AsyncHide(GameObject obj, int seconds = 3)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }

    private void Update()
    {
        ShowSelectableOptions();
    }

    private void ShowSelectableOptions()
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

    private void ShowMap()
    {
        if (!_MinimapCanvas.activeInHierarchy)
        {
            ToggleObjects(mainUIPanels, false);
            _MinimapCanvas.SetActive(true);
            StartCoroutine(AsyncHide(_MinimapCanvas, 5));
            StartCoroutine(AsyncToggleObjects(ToggleObjects, mainUIPanels, true, 5));
            PlayerPrefs.SetInt(Prefs.MAP_INVOCATIONS.ToString(), PlayerPrefs.GetInt(Prefs.MAP_INVOCATIONS.ToString()) + 1);
        }
    }

    private void SetStartGameUI()
    {
        ToggleObjects(mainUIPanels, true);
        _wrongItemsListPanel.GetComponent<Canvas>().enabled = false;
    }

    private void SetEndGameUI()
    { 
        ToggleObjects(mainUIPanels, true);
        _MinimapCanvas.SetActive(false);
        _wrongItemsListPanel.GetComponent<Canvas>().enabled = true;
        _wrongItemsListPanel.GetComponent<CheckListManager>().DisplayElapsedTimes();
        _listPanel.GetComponent<CheckListManager>().DisplayElapsedTimes();
    }


    IEnumerator AsyncToggleObjects(Action<List<GameObject>, bool> func, List<GameObject> list, bool status = true, int seconds = 3)
    {
        yield return new WaitForSeconds(seconds);
        func(list, status);


    }
    private void ToggleObjects(List<GameObject> objectsList, bool status = true)
    {
        foreach (var obj in objectsList.ToArray())
        {
            obj.SetActive(status);
        }
    }
    
}
