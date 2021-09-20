using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //
    // Start is called before the first frame update

    public Canvas canvas;
    private GameObject canvasGameObject;
    private Text variableText;
    private GameObject variableTextGO;
    private GameObject commonTextGO;
    private Text commonText;

    //public Text variableText;
    //public Text commonText;
    private void Awake()
    {
        if (canvas != null)
        {
            canvasGameObject = canvas.gameObject;
            var tests = canvasGameObject?.GetComponentsInChildren<Text>();
            //variableText = canvasGameObject?.GetComponentInChildren<Text>();
            //commonText = canvasGameObject?.GetComponentInChildren<Text>();

            var test = GameObject.FindGameObjectWithTag("Text_startgame");
            variableText = GameObject.FindGameObjectWithTag("Text_startgame").GetComponent<Text>();
            commonText = GameObject.FindGameObjectWithTag("Text_PickedObject").GetComponent<Text>();
        }
    }

    /*

    void Start()
    {
        
        //Debug.Log(canvas);
        //if (canvas != null)
        //{
        //    canvasGameObject = canvas.gameObject;
        //    var tests = canvasGameObject.GetComponentsInChildren<Text>();
        //    variableText = canvas.gameObject.GetComponentInChildren<Text>();
        //    commonText = canvas.gameObject.GetComponentInChildren<Text>();
        //    Debug.Log(variableText);
        //    Debug.Log(commonText);

        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */

    private void OnEnable()
    {
        
        PlayerManager.OnPlayerStartedGame += DisplayBasicUI;
        PlayerManager.OnPlayerEndedGame += DisplayBasicUI;
    }

    private void OnDisable()
    {
        PlayerManager.OnPlayerStartedGame -= DisplayBasicUI;
        PlayerManager.OnPlayerEndedGame -= DisplayBasicUI;
    }


    void DisplayPickedObject (string name)
    {
        variableText.gameObject.SetActive(true);
        variableText.text = name.ToString();
        //canvas.GetComponentInChildren<TextMesh>().text = name;
        StartCoroutine(LateCall(variableText.gameObject));
    }


    void DisplayBasicUI ()
    {
        variableText.gameObject.SetActive(true);
        variableText.text = "Game Started!";

        commonText.gameObject.SetActive(true);
        commonText.text = "Game Started!";
        //canvas.GetComponentInChildren<Text>().text = "Game Started!";
        StartCoroutine(LateCall(variableText.gameObject));
        StartCoroutine(LateCall(commonText.gameObject));
    }

    IEnumerator LateCall(GameObject gameObject)
    {

        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
