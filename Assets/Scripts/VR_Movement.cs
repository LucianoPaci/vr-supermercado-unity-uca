using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class VR_Movement : MonoBehaviour
{
    // VR Main Camera

    private Transform vrCamera;

    // Speed to move the player
    public float speed = 3f;

    CharacterController myCC;

    void Start()
    {
        // Find the CharacterController
        myCC = gameObject.GetComponent<CharacterController>();

        // Find the main camera
        vrCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Move with SimpleMove based on Horizontal and Vertical Input

        myCC.SimpleMove(speed * vrCamera.TransformDirection(Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal")));

    }
}
