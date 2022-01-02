using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> onClick)
    {
        button.onClick.AddListener(delegate()
        {
            onClick(param);
        });

    }
}
public class SelectableOptionItem : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update

    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text subtitle;

    private Entity associatedEntity;
    private Button button;
    private GameObject titleObject;

    private GameObject subtitleObject;

    private Action<Entity> delegatedAction = null;

    void Start()
    {
        title = this.transform.Find("Title").GetComponent<TMP_Text>();
        titleObject = title.gameObject;
        
        subtitle = this.transform.Find("Subtitle").GetComponent<TMP_Text>();
        subtitleObject = subtitle.gameObject;
        
        subtitleObject.SetActive(false);
        
        button = this.gameObject.GetComponentInParent<Button>();
    }

    public void SetObjectInfo(Entity e, Action<Entity> returnEntity, string title, [Optional] string subtitle )
    {

        this.title = this.transform.Find("Title").GetComponent<TMP_Text>();
        this.button = this.gameObject.GetComponentInParent<Button>();
        this.delegatedAction = returnEntity;

        this.associatedEntity = e;
        this.title.SetText(title);
        this.button.AddEventListener(this.associatedEntity, returnEntity);

        if (subtitle!=null)
        {
            this.subtitle = this.transform.Find("Subtitle").GetComponent<TMP_Text>();
            this.subtitle.SetText(subtitle);
            subtitleObject.SetActive(true);

        }


    }
    
    public void DestroyOption()
    {
        Destroy(gameObject);
    }
    

    public void OnPointerClick(PointerEventData eventData)
    {
        HandleSelect();
    }

    public void HandleSelect()
    {
        this.delegatedAction(this.associatedEntity);
    }
    
}
