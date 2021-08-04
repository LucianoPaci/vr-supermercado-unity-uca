using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRTargetItem : MonoBehaviour
{

    public UnityEvent m_gazeEnterEvent;
    public UnityEvent m_gazeExitEvent;

    public UnityEvent m_clickEvent;

    private Selectable m_selectable;
    private ISubmitHandler m_submit;
    // Start is called before the first frame update
    private void Awake()
    {
        m_selectable = GetComponent<Selectable>();
        m_submit = GetComponent<ISubmitHandler>();

    }

    public void GazeEnter(PointerEventData pointer)
    {
        if (m_selectable)
            m_selectable.OnPointerEnter(pointer);
        else
            m_gazeEnterEvent.Invoke();
    }

    public void GazeExit(PointerEventData pointer)
    {
        if (m_selectable)
            m_selectable.OnPointerExit(pointer);
        else
            m_gazeExitEvent.Invoke();
    }

    public void GazeClick(PointerEventData pointer)
    {
        if (m_submit != null)
            m_submit.OnSubmit(pointer);
           
        else
            m_clickEvent.Invoke();
    }
}
