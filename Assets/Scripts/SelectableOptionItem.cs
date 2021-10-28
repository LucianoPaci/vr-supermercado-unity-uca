using System;
using System.Collections;
using System.Collections.Generic;
using Gvr.Internal;
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
public class SelectableOptionItem : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text subtitle;

    private Entity associatedEntity;
    private Button button;

    void Start()
    {
        this.title = this.transform.Find("Title").GetComponent<TMP_Text>();
        this.subtitle = this.transform.Find("Subtitle").GetComponent<TMP_Text>();
        this.button = this.gameObject.GetComponentInParent<Button>();
    }

    public void SetObjectInfo(string title, string subtitle, Entity e, Action<Entity> returnEntity)
    {

        this.title = this.transform.Find("Title").GetComponent<TMP_Text>();
        this.subtitle = this.transform.Find("Subtitle").GetComponent<TMP_Text>();
        this.button = this.gameObject.GetComponentInParent<Button>();
        

        this.associatedEntity = e;
        this.title.SetText(title);
        this.subtitle.SetText(subtitle);
        this.button.AddEventListener(this.associatedEntity, returnEntity);

    }
    
    
    

    public void DestroyOption()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
