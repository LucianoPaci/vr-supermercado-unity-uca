using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField]
    Transform rotationCenter;
    [SerializeField]
    float rotationRadius = 2f, angularSpeed = 2f;
    float posX, posY, angle = 0f;
    public float Elemento1=1;
    public float Elemento2=1;
    public float Randominador;

    private void Update()
    {
        posX = Elemento2+rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = Elemento1+rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2(posX,posY);
        angle = angle + angularSpeed;
        if (angle >= 360f)
            angle = 0f;
    }
}
