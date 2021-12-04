using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [Header("Where to render")]
    public Transform content;
    
    [Header("What to render")] 
    public GameObject selectableOptionPrefab;

    [Header("Options Title")] public TMP_Text titleText;

    [Header("Options List")] public List<SelectableOptionItem> selectableOptionsList = new List<SelectableOptionItem>();
    
    private Canvas canvas;
    public bool isLoading = false;
    public static event Action<bool> OnDisplayingOptions;

    private void Awake()
    {

        canvas = this.GetComponent<Canvas>();
        canvas.enabled = false;
        SelectController.OnSelectingEntity += DisplayPickingOptions;

    }

    private void OnDestroy()
    {
        SelectController.OnSelectingEntity -= DisplayPickingOptions;
        canvas.enabled = false;
    }

    public void DisplayPickingOptions(List<Entity> entities)
    {
        if (entities.Count > 0 && !canvas.enabled)
        {
            selectableOptionsList.Clear();
            if (entities.Count == 1)
            {
                titleText.SetText("Deseas comprar " + entities.First().GetKey() + " ?");
                CreateOptionObject(entities.First(), "SI");
                CreateOptionObject(null, "NO");
            }
            else if (entities.Count > 1)
            {
                titleText.SetText("Qué deseas comprar?");
                foreach (var entity in entities)
                {
                    CreateOptionObject(entity, entity.GetKey());
                }
                CreateOptionObject(null, "Cancelar");
            }
        }
        
      
        
    }

    void CreateOptionObject(Entity e, string title, [Optional] string subtitle )
    {
        GameObject item = Instantiate(selectableOptionPrefab);
        item.transform.SetParent(content, false);
        
        SelectableOptionItem itemObject = item.GetComponent<SelectableOptionItem>();
        itemObject.SetObjectInfo(e, TriggerEntitySelection, title, subtitle );
        
        selectableOptionsList.Add(itemObject);
    }

    void TriggerEntitySelection(Entity e)
    {
        DisableCanvas();
        SelectController.GetEntity(e);
    }

    public IEnumerator DisableCanvasLateCall(int seconds = 3)
    {   
            isLoading = true;
            yield return new WaitForSeconds(seconds);
            DisableCanvas();
            isLoading = false;
    }

    private void DisableCanvas()
    {
        canvas.enabled = false;
        OnDisplayingOptions?.Invoke(false);
        selectableOptionsList.Clear();
        foreach (var option in content.GetComponentsInChildren<SelectableOptionItem>())
        {
            option.DestroyOption();
        }
        
    }
}
