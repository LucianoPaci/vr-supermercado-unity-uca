using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;

public class SoloUsoPrueba : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [SerializeField]
    private string esto;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            sALIR();
        }
    }
    public void sALIR()
    {

        Application.Quit();
        Debug.Log("Se ah salido del juego");
    }
    void Reset()
    {
        SceneManager.LoadScene(esto);
    }
}
