using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlsMenuController : MonoBehaviour
{

   [SerializeField]
   private List<GameObject> Options;

   [SerializeField] private GameObject PlayerSpeed;
   [SerializeField] private GameObject PlayerRotation;

   private void Awake()
   {
      if (PlayerPrefs.HasKey(Prefs.ROTATION_SPEED.ToString()))
      {
         OnHandlePlayerRotationChange(PlayerPrefs.GetFloat(Prefs.ROTATION_SPEED.ToString()));
      }
      
      if (PlayerPrefs.HasKey(Prefs.MOVEMENT_SPEED.ToString()))
      {
         OnHandlePlayerSpeedChange(PlayerPrefs.GetFloat(Prefs.MOVEMENT_SPEED.ToString()));
      }
      DontDestroyOnLoad(this);
      
      
      
   }

   private void Start()
   {
      ChangeColor();
      
   }


   public void OnHandlePlayerSpeedChange(float value)
   {
      
      TMP_Text textValue = PlayerSpeed.GetComponentInChildren<TMP_Text>();
      Slider slider = PlayerSpeed.GetComponentInChildren<Slider>();
      textValue.text = value.ToString();
      slider.value = value;
      
      PlayerPrefs.SetFloat(Prefs.MOVEMENT_SPEED.ToString(), value);
   }

   public void OnHandlePlayerRotationChange(float value)
   {
      TMP_Text textValue = PlayerRotation.GetComponentInChildren<TMP_Text>();
      Slider slider = PlayerRotation.GetComponentInChildren<Slider>();
      textValue.text = value.ToString();
      slider.value = value;
      
      PlayerPrefs.SetFloat(Prefs.ROTATION_SPEED.ToString(), value);
   }

   public void ChangeColor()
   {
      string controlsSchema = PlayerPrefs.GetString(Prefs.CONRTROLS_SCHEMA.ToString());
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
      PlayerPrefs.SetString(Prefs.CONRTROLS_SCHEMA.ToString(), ControlSchema.TYPE_A.ToString());
      ChangeColor();
   }
   
   public void OnSelect_TypeB()
   {
      PlayerPrefs.SetString(Prefs.CONRTROLS_SCHEMA.ToString(), ControlSchema.TYPE_B.ToString());
      ChangeColor();
   }
   
   
   
}
