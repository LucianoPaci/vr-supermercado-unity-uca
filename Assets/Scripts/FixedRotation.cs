using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotation : MonoBehaviour
{
    Transform t;
    public float fixedRotation = 0;
 
    void Start () {
        t = transform;
    }
     
    void Update () {
        t.eulerAngles = new Vector3 (t.eulerAngles.x, fixedRotation, t.eulerAngles.z);
    }
}
