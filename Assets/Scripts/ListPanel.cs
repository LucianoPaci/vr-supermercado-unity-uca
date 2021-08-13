using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ListPanel : MonoBehaviour
{

    [SerializeField] private TMP_Text _text;


    private Entity _boundEntity;
    private List<CheckListItem> _checkListObjects = new List<CheckListItem>();
    
    private void Awake()
    {
        _checkListObjects = GetComponent<CheckListManager>().GetList();
    }

    private void OnDestroy()
    {
        if(_boundEntity != null)
        {
            _boundEntity.OnStatusChanged -= HandleStatusChanged;
        }
    }

    public void Bind(Entity entity)
    {
        if (_boundEntity != null)
        {
            _boundEntity.OnStatusChanged -= HandleStatusChanged;
        }

        _boundEntity = entity;

        if(_boundEntity != null)
        {
            _boundEntity.OnStatusChanged += HandleStatusChanged;
            HandleStatusChanged(_boundEntity);
        }
    }
    
    private void HandleStatusChanged(Entity entity)
    {
        CheckListItem found = _checkListObjects.Find(lo => lo.key == entity.GetKey().ToLower());
        if(found)
        {
            found.gameObject.GetComponentInParent<Toggle>().isOn = true;
            _text.SetText("Picked " + entity.GetKey());
        }
        
       
    }
}
