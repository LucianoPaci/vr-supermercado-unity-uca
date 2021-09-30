using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ListPanel : MonoBehaviour
{
    private Entity _boundEntity;
    private List<CheckListItem> _checkListObjects = new List<CheckListItem>();
    
    private void Awake()
    {
        _checkListObjects = GetComponent<CheckListManager>().GetList();
        this.gameObject.SetActive(false);
        GameManager.OnNewElementAddedToDictionary += AddTimeToListItem;
    }

    private void OnDestroy()
    {
        if(_boundEntity != null)
        {
            _boundEntity.OnStatusChanged -= HandleStatusChanged;
        }
        GameManager.OnNewElementAddedToDictionary -= AddTimeToListItem;
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
        }
        
       
    }
    
    void AddTimeToListItem(Entity e)
    {
        if (e != null)
        {
            EntityWithTime ewt = GameManager.GetEntityWithTime(e.GetKey());
            try
            {
                if (ewt != null)
                {
                    CheckListItem listItem = _checkListObjects.Find(item => item.key == ewt.entity.GetKey());
                    if (listItem != null)
                    {
                        listItem.GetComponentInChildren<TMP_Text>().text = ewt.elaspedTime;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
              
            }
        }
       
       
    }
}
