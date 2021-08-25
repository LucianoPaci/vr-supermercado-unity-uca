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

    private float elapsedTime = 0f;

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

        Entity[] entitiesArray = entities.ToArray();
        
        if (entities.Count == 1)
        {
            titleText.SetText("Deseas comprar " + entities.First().GetKey() + " ?");
            CreateOptionObject("SI", "Presionar 1", entities.First());
            CreateOptionObject("NO", "Presionar 2", null);
        }
        else if (entities.Count > 1)
        {
            titleText.SetText("Qué deseas comprar?");
            int index = 0;
            foreach (var entity in entities)
            {
                CreateOptionObject(entity.GetName(), "Presionar algo", entity);
                index++;
            }
            CreateOptionObject("Cancelar", "--", null);
        }
        
    }

    void CreateOptionObject(string title, string subtitle, Entity e)
    {
        GameObject item = Instantiate(selectableOptionPrefab);
        item.transform.SetParent(content, false);
        
        SelectableOptionItem itemObject = item.GetComponent<SelectableOptionItem>();
        itemObject.SetObjectInfo(title, subtitle, e);
        
        selectableOptionsList.Add(itemObject);
    }
    
    // Update is called once per frame
    void Update()
    {
       
        
        if (selectableOptionsList.Count > 0)
        {
            if (canvas.enabled)
            {
                elapsedTime += Time.deltaTime;
                StartCoroutine(DisableCanvasLateCall());
               
            }
            else
            {
                elapsedTime += Time.deltaTime;
                canvas.enabled = true;
                OnDisplayingOptions?.Invoke(true);
            }
        }

           
    }
    IEnumerator DisableCanvasLateCall()
    {
   
            yield return new WaitForSeconds(3);
           
            canvas.enabled = false;
            OnDisplayingOptions?.Invoke(false);
            selectableOptionsList.Clear();
            foreach (var option in content.GetComponentsInChildren<SelectableOptionItem>())
            {
                option.DestroyOption();
            }
            
    }
}
