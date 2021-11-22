using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsMenuController : MonoBehaviour
{

   [SerializeField]
   private List<GameObject> Options;

   private void Awake()
   {
      DontDestroyOnLoad(this);
   }

   private void Start()
   {
      ChangeColor();
   }

   // private void Update()
   // {
   //    ChangeColor(controlsSchema);
   // }


   public void ChangeColor()
   {
      string controlsSchema = PlayerPrefs.GetString("ControlsSchema");
      foreach (var option in Options.ToArray())
      {
         
         var img = option.GetComponentInChildren<RawImage>();
         if (option.name == controlsSchema)
         {
            img.color = Color.green;
         }
         else
         {
            img.color = Color.white;
         }
      }
   }
   public void OnBack()
   {
      MenuManager.OpenMenu(Menu.MAIN_MENU, gameObject);
   }
   
   public void OnSelect_TypeA()
   {
      PlayerPrefs.SetString("ControlsSchema", ControlSchema.TYPE_A.ToString());
      ChangeColor();
   }
   
   public void OnSelect_TypeB()
   {
      PlayerPrefs.SetString("ControlsSchema", ControlSchema.TYPE_B.ToString());
      ChangeColor();
   }

   
   
}
