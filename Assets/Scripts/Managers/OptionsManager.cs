using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public static event Action<Entity> ReturnEntity;

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

    private void Start()
    {
        // Instanciar los prefabs como botones
      
    }
    

    public void DisplayPickingOptions(List<Entity> entities)
    {
        if (entities.Count > 0 && !canvas.enabled)
        {
            selectableOptionsList.Clear();
            if (entities.Count == 1)
            {
                titleText.SetText("Deseas comprar " + entities.First().GetKey() + " ?");
                CreateOptionObject("SI", "Presionar 1", entities.First());
                CreateOptionObject("NO", "Presionar 2", null);
            }
            else if (entities.Count > 1)
            {
                titleText.SetText("Qué deseas comprar?");
                foreach (var entity in entities)
                {
                    CreateOptionObject(entity.GetName(), "Presionar algo", entity);
                }
                CreateOptionObject("Cancelar", "--", null);
            }
        }
        
      
        
    }

    void CreateOptionObject(string title, string subtitle, Entity e)
    {
        GameObject item = Instantiate(selectableOptionPrefab);
        item.transform.SetParent(content, false);
        
        SelectableOptionItem itemObject = item.GetComponent<SelectableOptionItem>();
        itemObject.SetObjectInfo(title, subtitle, e, TriggerEntitySelection);
        
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
