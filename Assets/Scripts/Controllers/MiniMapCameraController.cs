using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCameraController : MonoBehaviour
{

    Transform target;
    float defaultPosY;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        defaultPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Apply position
        transform.position = new Vector3(target.position.x, defaultPosY, target.position.z);
        // Apply rotation
        // transform.rotation = Quaternion.Euler(90, target.eulerAngles.y, 0);
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}