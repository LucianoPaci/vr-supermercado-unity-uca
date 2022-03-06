﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
public class MenuManager: MonoBehaviour
{
    // public static bool IsInitialized { get; private set; } 
    public static GameObject mainMenu, controlsMenu;

    private void Awake()
    {
        GameObject canvas = GameObject.Find("MainMenuCanvas");
        mainMenu = canvas.transform.Find("MainMenuPanel").gameObject;
        controlsMenu = canvas.transform.Find("ControlsMenuPanel").gameObject;
    }
    
    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {

        switch (menu)
        {
            case Menu.MAIN_MENU:
                mainMenu.SetActive(true);
                break;
            case Menu.CONTROLS:
                controlsMenu.SetActive(true);
                break;
            
        }
        
        callingMenu.SetActive(false);
    }
}
