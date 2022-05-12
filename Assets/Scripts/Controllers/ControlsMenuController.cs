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
   [SerializeField] private float RotationSteps = 10f;
   [SerializeField] private float MovementSteps = 1f;

    private float ROTATION_MAX = 100f;
    private float SPEED_MAX = 10f;
    private float ROTATION_MIN = 10f;
    private float SPEED_MIN = 1f;

    private TMP_Text rotationTextValue;
    private TMP_Text speedTextValue;

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
      rotationTextValue = PlayerRotation.GetComponentInChildren<TMP_Text>();
      speedTextValue = PlayerSpeed.GetComponentInChildren<TMP_Text>();
   }

    public void OnHandleChangeRotation(string action)
    {
       float result = 0f;
       float actualRotationSpeed = PlayerPrefs.GetFloat(Prefs.ROTATION_SPEED.ToString());
       
       if (action == "INCREASE")
       {
          result = actualRotationSpeed + RotationSteps;
       }
       else if (action == "DECREASE")
       {
          result = actualRotationSpeed - RotationSteps;
       }
       
       if (!isBetweenLimits(result, ROTATION_MAX, ROTATION_MIN)) return;
       rotationTextValue.text = result.ToString();
       PlayerPrefs.SetFloat(Prefs.ROTATION_SPEED.ToString(), result);
      
    }

    public void OnHandleChangeMovementSpeed(string action)
    {
       float result = 0f;
       float actualMovementSpeed = PlayerPrefs.GetFloat(Prefs.MOVEMENT_SPEED.ToString());
       
       if (action == "INCREASE")
       {
          result = actualMovementSpeed + MovementSteps;
       }
       else if (action == "DECREASE")
       {
          result = actualMovementSpeed - MovementSteps;
       }
       
       if (!isBetweenLimits(result, SPEED_MAX, SPEED_MIN)) return;
       speedTextValue.text = result.ToString();
       PlayerPrefs.SetFloat(Prefs.MOVEMENT_SPEED.ToString(), result);
    }
    
    public void OnHandlePlayerSpeedChange(float value)
   {
      
      TMP_Text textValue = PlayerSpeed.GetComponentInChildren<TMP_Text>();

      textValue.text = value.ToString();

      PlayerPrefs.SetFloat(Prefs.MOVEMENT_SPEED.ToString(), value);
   }

   public void OnHandlePlayerRotationChange(float value)
   {
      TMP_Text textValue = PlayerRotation.GetComponentInChildren<TMP_Text>();
      textValue.text = value.ToString();
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

   private bool isBetweenLimits(float val, float max, float min)
   {
      var integerVal = (int) val;
      var integerMax = (int) max;
      var integerMin = (int) min;
      return integerVal >= integerMin && integerVal <= integerMax;
   }
   
}
