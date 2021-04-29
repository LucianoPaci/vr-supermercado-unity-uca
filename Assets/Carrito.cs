using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Carrito : MonoBehaviour
{

    public GameObject ObjetoenCuestion;
    void OnCollisionEnter(Collision collision)
    {
        print("oasidj");
        ObjetoenCuestion.SetActive(true);
    }
}
