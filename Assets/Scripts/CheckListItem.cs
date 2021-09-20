using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CheckListItem : MonoBehaviour
{
    public string label;
    public bool required;
    public string key;

    private Text itemText;

    private void Start()
    {
        itemText = GetComponentInChildren<Text>();
        itemText.text = label;
    }

    public void SetObjectInfo(string label, bool required, string key)
    {
        itemText = GetComponentInChildren<Text>();

        this.label = label;
        this.required = required;
        this.key = key;
        this.itemText.text = label;
    }
}
