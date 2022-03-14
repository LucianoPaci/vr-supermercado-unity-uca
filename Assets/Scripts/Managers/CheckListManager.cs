using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                CreateCheckListObject(plainItem.label, plainItem.required, plainItem.key);
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



