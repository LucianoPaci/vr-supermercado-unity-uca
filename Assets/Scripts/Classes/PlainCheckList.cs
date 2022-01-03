using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 /*
  * To Parse some JSON data, we must create Serializable Plain Classes
  */
[System.Serializable]
public class PlainCheckList
{
    public List<PlainCheckListItem> checkList;
}