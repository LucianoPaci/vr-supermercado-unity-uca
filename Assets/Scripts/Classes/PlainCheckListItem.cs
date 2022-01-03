using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
