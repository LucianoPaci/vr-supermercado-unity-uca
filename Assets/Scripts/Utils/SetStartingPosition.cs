using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartingPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 position;
    void Start()
    {
        transform.localPosition = position;
    }
    
}
