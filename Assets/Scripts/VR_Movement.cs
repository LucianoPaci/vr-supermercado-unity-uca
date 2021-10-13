using UnityEngine;

// Hacemos requerido el Componente de este tipo. Sin él, Unity lanza una excepción
[RequireComponent(typeof(CharacterController))]
public class VR_Movement : MonoBehaviour
{
    // Camara Principal de VR
    private Transform vrCamera;

    // Velocidad del jugador
    public float speed = 3f;

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
        // Se utiliza el metodo SimpleMove, basado en input horizontal y vertical 
        myCC.SimpleMove(speed * vrCamera.TransformDirection(Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal")));

    }
}
