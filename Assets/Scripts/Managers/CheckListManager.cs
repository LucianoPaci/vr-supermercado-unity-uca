using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
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
    }
    

    void LoadJSONFile()
    {
        if(jsonText)
        {
            PlainCheckList plainList = JsonUtility.FromJson<PlainCheckList>(jsonText.text);

            foreach (PlainCheckListItem plainItem in plainList.checkList)
            {
                CreateCheckListObject(plainItem.label, plainItem.required);
            }

        }
    }

    void CreateCheckListObject(string label, bool required)
    {
        GameObject item = Instantiate(checkListItemPrefab);
        item.transform.SetParent(content, false);

        CheckListItem itemObject = item.GetComponent<CheckListItem>();
        itemObject.SetObjectInfo(label, required);

        checkListObjects.Add(itemObject);

    }

    public List<CheckListItem> GetList()
    {
        return checkListObjects;
    }

}



