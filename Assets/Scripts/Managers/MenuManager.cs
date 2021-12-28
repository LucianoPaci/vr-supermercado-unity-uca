using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuManager: MonoBehaviour
{
    // public static bool IsInitialized { get; private set; } 
    public static GameObject mainMenu, controlsMenu;

    private void Awake()
    {
        PlayerPrefs.SetString("ControlsSchema", ControlSchema.TYPE_A.ToString());
        GameObject canvas = GameObject.Find("Canvas");
        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        controlsMenu = canvas.transform.Find("ControlsMenu").gameObject;
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
