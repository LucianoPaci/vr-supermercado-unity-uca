using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCameraController : MonoBehaviour
{

    Transform target;
    float defaultPosY;
    
    void Start()
    {
        target = PlayerManager.GetPlayer().transform;
        defaultPosY = transform.position.y;
    }
    void Update()
    {
        // Apply position
        transform.position = new Vector3(target.position.x, defaultPosY, target.position.z);
        // Apply rotation
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}