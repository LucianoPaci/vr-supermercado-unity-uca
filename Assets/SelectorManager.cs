using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class SelectorManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    private Transform _selection;

    [SerializeField] private GameObject ProductosErroneos;

    [SerializeField] private GameObject PE_Cerdo;
    [SerializeField] private GameObject PE_Pollo;
    [SerializeField] private GameObject PE_Osito;
    [SerializeField] private GameObject PE_Auto;
    [SerializeField] private GameObject PE_Monitor;
    [SerializeField] private GameObject PE_Pelota;
    [SerializeField] private GameObject PE_Balanceado;
    [SerializeField] private GameObject PE_Perfume;
    [SerializeField] private GameObject PE_Leche;
    [SerializeField] private GameObject PE_Crema;

    private bool boolCarne;
    private bool boolVerdura;
    private bool boolHarinas;
    private bool boolLacteos;
    private bool boolBebidas;
    private bool boolPanaderia;
    private bool boolJuguetes;

    [SerializeField] private GameObject _carne;
    [SerializeField] private GameObject _verdura;
    [SerializeField] private GameObject _harinas;
    [SerializeField] private GameObject _lacteos;
    [SerializeField] private GameObject _bebidas;
    [SerializeField] private GameObject _panaderia;
    [SerializeField] private GameObject _juguetes;

    [SerializeField] private GameObject _monitor;
    [SerializeField] private GameObject _pelota;
    [SerializeField] private GameObject _perfume;
    [SerializeField] private GameObject _balanceado;

    [SerializeField] private GameObject _cerdo;
    [SerializeField] private GameObject _pollo;
    [SerializeField] private GameObject _osito;
    [SerializeField] private GameObject _auto;
    [SerializeField] private GameObject _leche;
    [SerializeField] private GameObject _crema;

    [SerializeField] private GameObject CARNE;
    [SerializeField] private GameObject VERDURA;
    [SerializeField] private GameObject HARINAS;
    [SerializeField] private GameObject LACTEOS;
    [SerializeField] private GameObject BEBIDAS;
    [SerializeField] private GameObject PAN;
    [SerializeField] private GameObject JUGUETES;

    [SerializeField] private GameObject Iniciar;
    [SerializeField] private GameObject Terminar;
    [SerializeField] private Text Tiempo;

    [SerializeField] private GameObject feedbackCARNE;
    [SerializeField] private GameObject feedbackVERDURA;
    [SerializeField] private GameObject feedbackHARINAS;
    [SerializeField] private GameObject feedbackLACTEOS;
    [SerializeField] private GameObject feedbackBEBIDAS;
    [SerializeField] private GameObject feedbackPAN;
    [SerializeField] private GameObject feedbackJUGUETES;
    [SerializeField]
    private GameObject feedbackDEPORTES;
    [SerializeField]
    private GameObject feedbackPERFUME;
    [SerializeField]
    private GameObject feedbackELECTRONICA;
    [SerializeField] private GameObject feedbackVETERINARIA;

    [SerializeField] private Text GuardarTiempoCARNE;
    [SerializeField] private Text GuardarTiempoVERDURA;
    [SerializeField] private Text GuardarTiempoHARINAS;
    [SerializeField] private Text GuardarTiempoLACTEOS;
    [SerializeField] private Text GuardarTiempoBEBIDAS;
    [SerializeField] private Text GuardarTiempoPAN;
    [SerializeField] private Text GuardarTiempoJUGUETES;

    [SerializeField] private GameObject Resetboton;

    [SerializeField] private int sec;

    [SerializeField] private GameObject Minimapa_Camara;
    [SerializeField] private Text UsosMiniMapa;

    [SerializeField] private Text FinalFrase;
    [SerializeField] private GameObject cuadro;

    private int contador;

    private bool Iniciado;
    IEnumerator LateCall(GameObject esto)
    {

        yield return new WaitForSeconds(sec);

        esto.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StartGame"))
        {
            Tiempo.GetComponent<Timer>().tick = true;
            Iniciado = true;
        }

        // Logica que puede llevarse al gameController
        if(other.gameObject.CompareTag("EndGame"))
        {
            Finalizar();
        }    
    }
    public void carne()
    {
        feedbackCARNE.SetActive(false);
        CARNE.SetActive(true);
        _carne.SetActive(true);
        CarneBool = false;
    }
    public void queso()
    {
        feedbackLACTEOS.SetActive(false);
        LACTEOS.SetActive(true);
        _lacteos.SetActive(true);
    }
    public void juguetes()
    {
        feedbackJUGUETES.SetActive(false);
        JUGUETES.SetActive(true);
        _juguetes.SetActive(true);
    }
    public void Finalizar()
    {
        if (Iniciado)
        {
            Tiempo.GetComponent<Timer>().saveTime();
            Tiempo.GetComponent<Timer>().tick = false;
            Tiempo.GetComponent<Timer>().resettime();
            cuadro.SetActive(true);
            string esto = Tiempo.GetComponent<Timer>().tiempotextAnterior.text;

            FinalFrase.text = "Ud ha finalizado las compras con un tiempo total de " + esto + " tiempo";
            ProductosErroneos.SetActive(true);
            /*_panaderia.SetActive(false);
            PAN.SetActive(false);
            _verdura.SetActive(false);
            VERDURA.SetActive(false);
            _carne.SetActive(false);
            CARNE.SetActive(false);
            _bebidas.SetActive(false);
            BEBIDAS.SetActive(false);
            _harinas.SetActive(false);
            HARINAS.SetActive(false);
            _lacteos.SetActive(false);
            LACTEOS.SetActive(false);
            Iniciado = false;

            boolBebidas = false;
            boolCarne = false;
            boolHarinas = false;
            boolJuguetes = false;
            boolLacteos = false;
            boolPanaderia = false;
            boolVerdura = false;
            Iniciado = false;

            GuardarTiempoPAN.text = "00:00";
            GuardarTiempoVERDURA.text = "00:00";
            GuardarTiempoCARNE.text = "00:00";
            GuardarTiempoBEBIDAS.text = "00:00";
            GuardarTiempoHARINAS.text = "00:00";
            GuardarTiempoLACTEOS.text = "00:00";
            GuardarTiempoJUGUETES.text = "00:00";*/
            GuardarTiempoCARNE.gameObject.SetActive(true);
            GuardarTiempoVERDURA.gameObject.SetActive(true);
            GuardarTiempoHARINAS.gameObject.SetActive(true);
            GuardarTiempoJUGUETES.gameObject.SetActive(true);
            GuardarTiempoPAN.gameObject.SetActive(true);
            GuardarTiempoBEBIDAS.gameObject.SetActive(true);
            GuardarTiempoLACTEOS.gameObject.SetActive(true);


            SceneManager.LoadScene("Final");

        }

    }
    private bool CarneBool;
    private int stan;
    [SerializeField] private GameObject Opciones;
    [SerializeField] private Text SioNo;
    public void Condicionales()
    {
        switch (stan)
        {
            case 1://carne

                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetButtonDown("ButtonB"))
                {
                    carne();
                    //boolCarne = true;
                    //StartCoroutine(LateCall(feedbackCARNE));
                    feedbackCARNE.SetActive(false);
                    GuardarTiempoCARNE.text = Tiempo.GetComponent<Timer>().tiempotext.text;
                    stan = 0;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetButtonDown("ButtonC"))
                {
                    //queso();
                    //StartCoroutine(LateCall(feedbackCARNE));
                    feedbackCARNE.SetActive(false);
                    _pollo.SetActive(true);
                    PE_Pollo.SetActive(true);
                    stan = 0;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetButtonDown("ButtonA"))
                {
                    //juguetes();
                    //StartCoroutine(LateCall(feedbackCARNE));
                    feedbackCARNE.SetActive(false);
                    _cerdo.SetActive(true);
                    PE_Cerdo.SetActive(true);
                    stan = 0;
                }
                break;
            case 2://Juguetes

                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetButtonDown("ButtonB"))
                {
                    //carne();
                    StartCoroutine(LateCall(feedbackJUGUETES));
                    feedbackJUGUETES.SetActive(false);
                    _osito.SetActive(true);
                    PE_Osito.SetActive(true);
                    stan = 0;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetButtonDown("ButtonC"))
                {
                    //queso();
                    StartCoroutine(LateCall(feedbackJUGUETES));
                    feedbackJUGUETES.SetActive(false);
                    _auto.SetActive(true);
                    PE_Auto.SetActive(true);
                    stan = 0;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3)|| Input.GetButtonDown("ButtonA"))
                {
                    juguetes();
                    //boolJuguetes = true;
                    //StartCoroutine(LateCall(feedbackJUGUETES)); 
                    feedbackJUGUETES.SetActive(false);
                    GuardarTiempoJUGUETES.text = Tiempo.GetComponent<Timer>().tiempotext.text;
                    stan = 0;
                }
                break;
            case 3://Lacteos

                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetButtonDown("ButtonB"))
                {
                    //carne();
                    //StartCoroutine(LateCall(feedbackLACTEOS));
                    feedbackLACTEOS.SetActive(false);
                    _leche.SetActive(true);
                    PE_Leche.SetActive(true);
                    stan = 0;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetButtonDown("ButtonC"))
                {

                    //StartCoroutine(LateCall(feedbackLACTEOS));
                    //boolLacteos = true;
                    feedbackLACTEOS.SetActive(false);
                    GuardarTiempoLACTEOS.text = Tiempo.GetComponent<Timer>().tiempotext.text;
                    queso();
                    stan = 0;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetButtonDown("ButtonA"))
                {
                    //juguetes();
                    feedbackLACTEOS.SetActive(false);
                    //StartCoroutine(LateCall(feedbackLACTEOS));
                    _crema.SetActive(true);
                    PE_Crema.SetActive(true);
                    stan = 0;
                }
                break;
            case 4://Perfumes

                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetButtonDown("ButtonB"))
                {
                    feedbackPERFUME.SetActive(true);
                    StartCoroutine(LateCall(feedbackPERFUME));
                    Opciones.SetActive(false);
                    _perfume.SetActive(true);
                    PE_Perfume.SetActive(true);
                    stan = 0;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetButtonDown("ButtonC"))
                {
                    Opciones.SetActive(false);
                    stan = 0;
                }
                break;
            case 5://Electronica

                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetButtonDown("ButtonB"))
                {
                    feedbackELECTRONICA.SetActive(true);
                    StartCoroutine(LateCall(feedbackELECTRONICA));
                    Opciones.SetActive(false);
                    _monitor.SetActive(true);
                    PE_Monitor.SetActive(true);
                    stan = 0;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetButtonDown("ButtonC"))
                {
                    Opciones.SetActive(false);
                    stan = 0;
                }
                break;
            case 6://Deporte

                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetButtonDown("ButtonB"))
                {
                    feedbackDEPORTES.SetActive(true);
                    StartCoroutine(LateCall(feedbackDEPORTES));
                    Opciones.SetActive(false);
                    _pelota.SetActive(true);
                    PE_Pelota.SetActive(true);
                    stan = 0;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetButtonDown("ButtonC"))
                {
                    Opciones.SetActive(false);
                    stan = 0;
                }
                break;
            case 7://Harinas

                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetButtonDown("ButtonB"))
                {
                    boolHarinas = true;
                    _harinas.SetActive(true);
                    HARINAS.SetActive(true);
                    feedbackHARINAS.SetActive(true);
                    GuardarTiempoHARINAS.text = Tiempo.GetComponent<Timer>().tiempotext.text;
                    StartCoroutine(LateCall(feedbackHARINAS));
                    Opciones.SetActive(false);
                    stan = 0;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    Opciones.SetActive(false);
                    stan = 0;
                }
                break;
            case 8://Bebidas

                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetButtonDown("ButtonB"))
                {
                    boolBebidas = true;
                    _bebidas.SetActive(true);
                    BEBIDAS.SetActive(true);
                    feedbackBEBIDAS.SetActive(true);
                    GuardarTiempoBEBIDAS.text = Tiempo.GetComponent<Timer>().tiempotext.text;
                    StartCoroutine(LateCall(feedbackBEBIDAS));
                    Opciones.SetActive(false);
                    stan = 0;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetButtonDown("ButtonC"))
                {
                    Opciones.SetActive(false);
                    stan = 0;
                }
                break;
            case 9://Verduras

                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetButtonDown("ButtonB"))
                {
                    boolVerdura = true;
                    _verdura.SetActive(true);
                    VERDURA.SetActive(true);
                    feedbackVERDURA.SetActive(true);
                    GuardarTiempoVERDURA.text = Tiempo.GetComponent<Timer>().tiempotext.text;
                    StartCoroutine(LateCall(feedbackVERDURA));
                    Opciones.SetActive(false);
                    stan = 0;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetButtonDown("ButtonC"))
                {
                    Opciones.SetActive(false);
                    stan = 0;
                }
                break;
            case 10://Veterinaria

                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetButtonDown("ButtonB"))
                {
                    feedbackVETERINARIA.SetActive(true);
                    StartCoroutine(LateCall(feedbackVETERINARIA));
                    Opciones.SetActive(false);
                    _balanceado.SetActive(true);
                    PE_Balanceado.SetActive(true);
                    stan = 0;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetButtonDown("ButtonC"))
                {
                    Opciones.SetActive(false);
                    stan = 0;
                }
                break;

        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Minimapa_Camara.SetActive(true);
            contador = contador + 1;
            UsosMiniMapa.text = "" + contador.ToString("f0");
            StartCoroutine(LateCall(Minimapa_Camara));
        }
        Condicionales();
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit))
        if (GvrPointerInputModule.CurrentRaycastResult.isValid)
        {

            //var selection = hit.transform;
            var selection = GvrPointerInputModule.CurrentRaycastResult.gameObject.transform;

            //if (hit.distance < 5 && selection.CompareTag(selectableTag) && (Input.GetMouseButtonDown(0) || Input.GetButtonDown("BottomTrigger")))
                if (selection.CompareTag(selectableTag) && (Input.GetMouseButtonDown(0) || Input.GetButtonDown("BottomTrigger")))
                {
                string SELECTOR = selection.GetComponent<NombreObjeto>().Objeto;

                Debug.Log("SELECTOR" + SELECTOR);

                if (SELECTOR != null)
                {
                    switch (SELECTOR)
                    {
                        //case "Iniciar":
                        //    Tiempo.GetComponent<Timer>().tick = true;
                        //    UnityEngine.Debug.Log(SELECTOR);
                        //    Iniciado = true;
                        //    break;
                        //case "Terminar":
                        //    Tiempo.GetComponent<Timer>().saveTime();
                        //    Tiempo.GetComponent<Timer>().tick = false;
                        //    Tiempo.GetComponent<Timer>().resettime();
                        //    cuadro.SetActive(true);
                        //    string esto = Tiempo.GetComponent<Timer>().tiempotextAnterior.text;

                        //    Debug.Log("Tiempo!!! " + esto);

                        //    FinalFrase.text = "Ud a finalizado las compras con un tiempo total de " + esto;
                        //    _panaderia.SetActive(false);
                        //    PAN.SetActive(false);
                        //    _verdura.SetActive(false);
                        //    VERDURA.SetActive(false);
                        //    _carne.SetActive(false);
                        //    CARNE.SetActive(false);
                        //    _bebidas.SetActive(false);
                        //    BEBIDAS.SetActive(false);
                        //    _harinas.SetActive(false);
                        //    HARINAS.SetActive(false);
                        //    _lacteos.SetActive(false);
                        //    LACTEOS.SetActive(false);
                        //    _juguetes.SetActive(true);
                        //    JUGUETES.SetActive(false);

                        //    boolBebidas = false;
                        //    boolCarne = false;
                        //    boolHarinas = false;
                        //    boolJuguetes = false;
                        //    boolLacteos = false;
                        //    boolPanaderia = false;
                        //    boolVerdura = false;
                        //    Iniciado = false;

                        //    GuardarTiempoPAN.text = "00:00";
                        //    GuardarTiempoVERDURA.text = "00:00";
                        //    GuardarTiempoCARNE.text = "00:00";
                        //    GuardarTiempoBEBIDAS.text = "00:00";
                        //    GuardarTiempoHARINAS.text = "00:00";
                        //    GuardarTiempoLACTEOS.text = "00:00";
                        //    GuardarTiempoJUGUETES.text = "00:00";




                        //    break;
                        case "PANADERIA":
                            if (Iniciado && boolPanaderia != true)
                            {
                                boolPanaderia = true;
                                _panaderia.SetActive(true);
                                PAN.SetActive(true);
                                UnityEngine.Debug.Log(SELECTOR);
                                feedbackPAN.SetActive(true);
                                GuardarTiempoPAN.text = Tiempo.GetComponent<Timer>().tiempotext.text;
                                StartCoroutine(LateCall(feedbackPAN));

                            }
                            break;
                        case "VERDULERIA":
                            if (Iniciado && boolVerdura != true)
                            {

                                Opciones.SetActive(true);
                                SioNo.text = ("Desea agregar Verdura?");
                                stan = 9;
                            }
                            break;
                        case "CARNICERIA":
                            if (Iniciado && boolCarne != true)
                            {
                                //boolCarne = true;
                                //_carne.SetActive(true);
                                //CARNE.SetActive(true);
                                //UnityEngine.Debug.Log(SELECTOR);
                                feedbackCARNE.SetActive(true);
                                //GuardarTiempoCARNE.text = Tiempo.GetComponent<Timer>().tiempotext.text;
                                // StartCoroutine(LateCall(feedbackCARNE));
                                stan = 1;
                            }
                            break;
                        case "BEBIDAS":
                            if (Iniciado && boolBebidas != true)
                            {

                                Opciones.SetActive(true);
                                SioNo.text = ("Desea agregar Bebida?");
                                stan = 8;
                            }
                            break;
                        case "HARINAS":
                            if (Iniciado && boolHarinas != true)
                            {
                                /*boolHarinas = true;
                                _harinas.SetActive(true);
                                HARINAS.SetActive(true);
                                UnityEngine.Debug.Log(SELECTOR);
                                feedbackHARINAS.SetActive(true);
                                GuardarTiempoHARINAS.text = Tiempo.GetComponent<Timer>().tiempotext.text;
                                StartCoroutine(LateCall(feedbackHARINAS));*/
                                Opciones.SetActive(true);
                                SioNo.text = ("Desea agregar Harina?");
                                stan = 7;
                            }
                            break;
                        case "LACTEOS":
                            if (Iniciado && boolLacteos != true)
                            {
                                //boolLacteos = true;
                                //_lacteos.SetActive(true);
                                //LACTEOS.SetActive(true);
                                //UnityEngine.Debug.Log(SELECTOR);
                                feedbackLACTEOS.SetActive(true);
                                //GuardarTiempoLACTEOS.text = Tiempo.GetComponent<Timer>().tiempotext.text;
                                //StartCoroutine(LateCall(feedbackLACTEOS));
                                stan = 3;
                            }
                            break;
                        case "JUGUETES":
                            if (Iniciado && boolJuguetes != true)
                            {
                                //boolJuguetes = true;
                                //_juguetes.SetActive(true);
                                //JUGUETES.SetActive(true);
                                //UnityEngine.Debug.Log(SELECTOR);
                                feedbackJUGUETES.SetActive(true);
                                //GuardarTiempoJUGUETES.text = Tiempo.GetComponent<Timer>().tiempotext.text;
                                //StartCoroutine(LateCall(feedbackJUGUETES));
                                stan = 2;
                            }
                            break;
                        case "DEPORTE":
                            if (Iniciado)
                            {
                                //feedbackDEPORTES.SetActive(true);
                                //StartCoroutine(LateCall(feedbackDEPORTES));
                                Opciones.SetActive(true);
                                SioNo.text = ("Desea agregar Pelota?");
                                stan = 6;
                            }
                            break;
                        case "ELECTRONICA":
                            if (Iniciado)
                            {
                                //feedbackELECTRONICA.SetActive(true);
                                //StartCoroutine(LateCall(feedbackELECTRONICA));
                                Opciones.SetActive(true);
                                SioNo.text = ("Desea agregar Monitor?");
                                stan = 5;
                            }
                            break;
                        case "PERFUME":
                            if (Iniciado)
                            {
                                //feedbackPERFUME.SetActive(true);
                                //StartCoroutine(LateCall(feedbackPERFUME));
                                Opciones.SetActive(true);
                                SioNo.text = ("Desea agregar Perfume?");
                                stan = 4;
                            }
                            break;
                        case "VETERINARIA":
                            if (Iniciado)
                            {

                                Opciones.SetActive(true);
                                SioNo.text = ("Desea agregar Balanceado?");
                                stan = 10;
                            }
                            break;
                    }
                }
                _selection = selection;
            }
        }
    }
}
