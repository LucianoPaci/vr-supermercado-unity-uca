using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUICameraPosition : MonoBehaviour
{
    void Start()
        {
            var player = PlayerManager.GetPlayer();
            // var player = GameObject.FindGameObjectWithTag("CameraRig");

        if (player != null)
        {
            var playerCamera = player.GetComponentInChildren<Camera>();
            var playerPosition = player.transform.position;
            var playerRotation = player.transform.rotation;
            
            this.gameObject.transform.localPosition = playerPosition;
            this.gameObject.transform.localRotation = playerRotation;
            this.gameObject.transform.SetParent(playerCamera.transform);
            
            // this.gameObject.transform.SetParent(player.transform);
        }
    }
    
    }
