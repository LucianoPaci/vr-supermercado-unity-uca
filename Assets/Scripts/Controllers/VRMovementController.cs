using System;
using UnityEngine;

// Hacemos requerido el Componente de este tipo. Sin él, Unity lanza una excepción
[RequireComponent(typeof(Rigidbody))]
public class VRMovementController : MonoBehaviour
{
    // Camara Principal de VR
    private Transform vrCamera;

    // Velocidad del jugador
    public float speed = 3f;

    public float rotationSpeed = 100f;

    private Rigidbody myRb;
    private Vector3 movement;
    private float deltaRotation;
    private Quaternion rotation;
    
    void Start()
    {
        // Hallar la camara principal
        vrCamera = Camera.main.transform;
        
        // Hallar el Rigidbody del Personaje/Player
        myRb = gameObject.GetComponent<Rigidbody>();
        
        
    }
    
    private Quaternion GetRotation()
    {
        deltaRotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Vector3 eulerAngleVelocity = new Vector3(0, deltaRotation, 0);
        return Quaternion.Euler(eulerAngleVelocity);
    }
    
    private void MoveCharacter(Vector3 direction)
    {
        myRb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }

    private void RotateCharacter(Quaternion characterRotation)
    {
        myRb.MoveRotation(myRb.rotation * characterRotation);
    }
    
    void Update()
    {
        // De esta manera, el movimiento es unicamente vertical y se permite la rotacion
        if (PlayerPrefs.GetString(Prefs.CONRTROLS_SCHEMA.ToString()) == ControlSchema.TYPE_A.ToString())
        {
            movement = vrCamera.TransformDirection(Vector3.forward * Input.GetAxis("Vertical"));
            rotation = GetRotation();
            
        }
        else
        {
            // De esta manera, el movimiento es vertical y horizontal
            movement = vrCamera.TransformDirection(Vector3.forward * Input.GetAxis("Vertical") +
                                                   Vector3.right * Input.GetAxis("Horizontal"));
        }
    }

    private void FixedUpdate()
    {

        MoveCharacter(movement);
        
        if (deltaRotation != 0f)
        {
            RotateCharacter(rotation);    
        }
        
    }
    
    
 
}
