using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]


public class OnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{


    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        Debug.Log("eventData > " + eventData);
        OnHoverEnter();
    }


    public void OnPointerExit(PointerEventData eventData)
    {

        OnHoverExit();
    }


    public void OnPointerClick (PointerEventData eventData)
    {
        OnClick();
    }

 
  void OnHoverEnter() 
    {
        image.color = Color.gray;
    }
 
    void OnHoverExit()
    {
        image.color = Color.white;
    }
 
    void OnClick()
    {
        image.color = Color.blue;
    }
 
}


