using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    [SerializeField] private SelectorManager Caja;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) Caja.Finalizar();

    }
}
