using System;
using UnityEngine;

// We make the Rigidbody a required component. Without it, Unity throws an exception
[RequireComponent(typeof(Rigidbody))]
public class VRMovementController : MonoBehaviour
{
    private Transform vrCamera;
    
    private float playerSpeed;
    private float rotationSpeed;

    private Rigidbody myRb;
    private Vector3 movement;
    private float deltaRotation;
    private Quaternion rotation;
    
    void Start()
    {
        // Find Main Camera
        vrCamera = Camera.main.transform;
        // Find Player's Rigidbody
        myRb = gameObject.GetComponent<Rigidbody>();

        rotationSpeed = PlayerPrefs.GetFloat(Prefs.ROTATION_SPEED.ToString());
        playerSpeed = PlayerPrefs.GetFloat(Prefs.MOVEMENT_SPEED.ToString());
    }
    
    private Quaternion GetRotation()
    {
        deltaRotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Vector3 eulerAngleVelocity = new Vector3(0, deltaRotation, 0);
        return Quaternion.Euler(eulerAngleVelocity);
    }
    
    private void MoveCharacter(Vector3 direction)
    {
        myRb.MovePosition(transform.position + (direction * playerSpeed * Time.deltaTime));
    }

    private void RotateCharacter(Quaternion characterRotation)
    {
        myRb.MoveRotation(myRb.rotation * characterRotation);
    }
    
    void Update()
    {
        // Vertical Movement and Rotation Allowed
        if (PlayerPrefs.GetString(Prefs.CONRTROLS_SCHEMA.ToString()) == ControlSchema.TYPE_A.ToString())
        {
            movement = vrCamera.TransformDirection(Vector3.forward * Input.GetAxis("Vertical"));
            rotation = GetRotation();
        }
        else
        {
            // Horizontal and vertical movement (Strafe allowed)
            movement = vrCamera.TransformDirection(Vector3.forward * Input.GetAxis("Vertical") +
                                                   Vector3.right * Input.GetAxis("Horizontal"));
        }
        
        rotationSpeed = PlayerPrefs.GetFloat(Prefs.ROTATION_SPEED.ToString());
        playerSpeed = PlayerPrefs.GetFloat(Prefs.MOVEMENT_SPEED.ToString());
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
