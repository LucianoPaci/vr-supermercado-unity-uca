using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;
using TMPro;

public class CheckListManager : MonoBehaviour
{
    [Header("JSON File with items list")]
    public TextAsset jsonText;

    [Header("Where to render")]
    public Transform content;

    [Header("What to render")]
    public GameObject checkListItemPrefab;

    [Header("List of Items")]
    public List<CheckListItem> checkListObjects = new List<CheckListItem>();

    

    /*
     * To Parse some JSON data, we must create Serializable Plain Classes
     */
    [System.Serializable]
    public class PlainCheckList
    {
        public List<PlainCheckListItem> checkList;
    }

    [System.Serializable]
    public class PlainCheckListItem
    {
        public string label;
        public bool required;
        public string key;

        public PlainCheckListItem(string label, bool required, string key)
        {
            this.label = label;
            this.required = required;
            this.key = key;
        }
    }

    private void Awake()
    {
       LoadJSONFile();
       GameManager.OnGameEnded += DisplayElapsedTimes;
       GameManager.OnNewElementAddedToDictionary += AddTimeToListItem;
    }

    private void OnDisable()
    {
        GameManager.OnGameEnded -= DisplayElapsedTimes;
        GameManager.OnNewElementAddedToDictionary -= AddTimeToListItem;
    }


    void LoadJSONFile()
    {
        if(jsonText)
        {
            PlainCheckList plainList = JsonUtility.FromJson<PlainCheckList>(jsonText.text);

            foreach (PlainCheckListItem plainItem in plainList.checkList)
            {
                CreateCheckListObject(plainItem.label, plainItem.required, plainItem.key);
            }

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
                    CheckListItem listItem = checkListObjects.Find(item => item.key == ewt.entity.GetKey());
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

    void CreateCheckListObject(string label, bool required, string key)
    {
        GameObject item = Instantiate(checkListItemPrefab);
        item.transform.SetParent(content, false);

        CheckListItem itemObject = item.GetComponent<CheckListItem>();
        itemObject.SetObjectInfo(label, required, key);

        checkListObjects.Add(itemObject);

    }

    public List<CheckListItem> GetList()
    {
        return checkListObjects;
    }

    public void DisplayElapsedTimes()
    {
        checkListObjects.ForEach(listObject => listObject.GetComponentInChildren<TMP_Text>().enabled = true);
    }

}



