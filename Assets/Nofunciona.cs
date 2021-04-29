using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nofunciona : MonoBehaviour
{
    public GameObject Harinas;
    public GameObject Bebidas;
    public GameObject Carniceria;
    public GameObject Verduras;
    public GameObject checkHarinas;
    public GameObject checkcarniceria;
    public GameObject checkverduras;
    public GameObject checkbebidas;

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            print("Verduras");
            Verduras.SetActive(true);
            checkverduras.SetActive(true);
        }
        else if (Input.GetKeyDown("2"))
        {
            print("Carniceria");
            Carniceria.SetActive(true);
            checkcarniceria.SetActive(true);
        }
        else if (Input.GetKeyDown("3"))
        {
            print("Bebidas");
            Bebidas.SetActive(true);
            checkbebidas.SetActive(true);
        }
        else if (Input.GetKeyDown("4"))
        {
            print("Harinas");
            Harinas.SetActive(true);
            checkHarinas.SetActive(true);
        }
        else if (Input.GetKeyDown("5"))
        {
            print("Reset");
            Harinas.SetActive(false);
            Verduras.SetActive(false);
            Carniceria.SetActive(false);
            Bebidas.SetActive(false);
            checkHarinas.SetActive(false);
            checkverduras.SetActive(false);
            checkcarniceria.SetActive(false);
            checkbebidas.SetActive(false);
        }
    }
}
