using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoader : MonoBehaviour
{
    // Update is called once per frame
    public string UISceneName;
    void Start()
    {
        if (UISceneName != null && !SceneManager.GetSceneByName(UISceneName).isLoaded)
        {
            SceneManager.LoadSceneAsync(UISceneName, LoadSceneMode.Additive);
        }
        
        else
        {
            // SceneManager.UnloadSceneAsync("UI");
        }
    }
}
