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

    private Transform trackedTransform; 

    CharacterController myCC;

    void Start()
    {
        // Hallar el Controlador del Personaje/Player
        myCC = gameObject.GetComponent<CharacterController>();
        

        // Hallar la camara principal
        vrCamera = Camera.main.transform;

        trackedTransform = vrCamera;

    }
    
    void Update()
    {
        MoveForward();
        Rotate();
    }

    private void MoveForward()
    {
        // De esta manera, el movimiento es vertical y horizontal
        // myCC.SimpleMove(speed * vrCamera.TransformDirection(Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal")));
        
        // De esta manera, el movimiento es unicamente vertical
        myCC.SimpleMove(speed * vrCamera.TransformDirection(Vector3.forward * Input.GetAxis("Vertical")));
    }
    
    void GlideLocomotion()
    {
        float forward = Input.GetAxis("Vertical");

        if (forward != 0f)
        {
            Vector3 moveDirection = Vector3.forward;
            if (trackedTransform != null)
            {
                moveDirection = trackedTransform.forward;
                moveDirection.y = 0f;
            }
            moveDirection *= -forward * speed * Time.deltaTime;
            myCC.transform.Translate(moveDirection);
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
