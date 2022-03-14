using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
   public static event Action OnGameResumed;
   private void Awake()
   {
      DontDestroyOnLoad(this);
   }
   public void OnSelect_Controls()
   {
      MenuManager.OpenMenu(Menu.CONTROLS, gameObject);
   }

   public void OnSelect_Training()
   {
      MenuManager.OpenMenu(Menu.TRAINING, gameObject);
   }

   public void OnSelect_Resume()
   {
      OnGameResumed?.Invoke();
   }
}
