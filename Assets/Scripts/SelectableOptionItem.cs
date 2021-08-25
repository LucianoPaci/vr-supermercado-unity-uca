using System;
using System.Collections;
using System.Collections.Generic;
using Gvr.Internal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

    KeyCode GetAssociatedKey(int index)
    {
        if (index == 1)
            return KeyCode.Alpha1;

        return KeyCode.Alpha0;
    }

    public void SetObjectInfo(string title, string subtitle, Entity e)
    {

        this.title = this.transform.Find("Title").GetComponent<TMP_Text>();
        this.subtitle = this.transform.Find("Subtitle").GetComponent<TMP_Text>();
        this.button = this.gameObject.GetComponentInParent<Button>();

        this.associatedEntity = e;
        this.title.SetText(title);
        this.subtitle.SetText(subtitle);
        
        //test
        this.button.onClick.AddListener(() => Debug.Log("PRESIONADO EL " + this.title));

    }

    public void DestroyOption()
    {
        Destroy(gameObject);
    }

    public Entity GetAssociatedEntity()
    {
        return this.associatedEntity;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
