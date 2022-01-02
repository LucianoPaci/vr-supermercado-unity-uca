using System;
using UnityEngine;

// Hacemos requerido el Componente de este tipo. Sin él, Unity lanza una excepción
[RequireComponent(typeof(CharacterController))]
public class VRMovementController : MonoBehaviour
{
    // Camara Principal de VR
    private Transform vrCamera;

    // Velocidad del jugador
    public float speed = 3f;

    public float rotationSpeed = 100f;
    
    CharacterController myCC;

    void Start()
    {
        // Hallar el Controlador del Personaje/Player
        myCC = gameObject.GetComponent<CharacterController>();
        

        // Hallar la camara principal
        vrCamera = Camera.main.transform;
        
    }
    
    void Update()
    {
        if (PlayerPrefs.GetString(Prefs.CONRTROLS_SCHEMA.ToString()) == ControlSchema.TYPE_A.ToString())
        {
            ExecuteLocomotion();
            Rotate();
        }
        else
        {
            ExecuteLocomotion(true);
        }
    }

    private void ExecuteLocomotion(bool allowStrafe = false)
    {
        // De esta manera, el movimiento es vertical y horizontal
        if (allowStrafe)
        {
            myCC.SimpleMove(speed * vrCamera.TransformDirection(Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal")));
        }
        else
        {
            // De esta manera, el movimiento es unicamente vertical
            myCC.SimpleMove(speed * vrCamera.TransformDirection(Vector3.forward * Input.GetAxis("Vertical")));
        }
        
    }
    
    private void Rotate()
    {
        var sideways = Input.GetAxis("Horizontal");
        if (sideways == 0f) return;
        var rotation = sideways * rotationSpeed * Time.deltaTime;
        myCC.transform.Rotate(0, rotation, 0);
    }
    
    
}
