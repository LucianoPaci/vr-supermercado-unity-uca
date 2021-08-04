using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public class Lookable : MonoBehaviour
{

    void Awake()
    {
        SetEventTrigger(EventTriggerType.PointerEnter, OnGazeEnter);
        SetEventTrigger(EventTriggerType.PointerExit, OnGazeExit);
        SetEventTrigger(EventTriggerType.PointerClick, OnGazeTrigger);

    }


    // Funcion que recibe un EventType y EventAction y permite setear los EventTriggers desde el codigo, sin usar UI


    // https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.EventTrigger.html
    // REVISAR POR QUE FALLA
    void SetEventTrigger(EventTriggerType eventType, Action<PointerEventData> eventAction)
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;
        entry.callback.AddListener((data) => { eventAction((PointerEventData)data); });
        trigger.triggers.Add(entry);

    }



    public void OnGazeEnter(PointerEventData data)
    {
        Debug.Log("-> OnGazeEnter <-");
    }

    public void OnGazeExit(PointerEventData data)
    {
        Debug.Log("-> OnGazeExit <-");
    }

    public void OnGazeTrigger(PointerEventData data)
    {
        Debug.Log("OnGazeTrigger: " + data.ToString());
    }
}
