using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMinimapCameraPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var minimapRef = GameObject.Find("MiniMapReference");

        // if (player != null)
        // {
        //     var playerPosition = player.transform.position;
        //     var playerRotation = player.transform.rotation;
        //     
        //     // this.gameObject.transform.localPosition = new Vector3(playerPosition.x, 25.0f, playerPosition.z);
        //     this.gameObject.transform.position = new Vector3(0, 25.0f, 0);
        //     // this.gameObject.transform.localRotation = Quaternion.LookRotation(Vector3.down);
        //     this.gameObject.transform.rotation = Quaternion.LookRotation(Vector3.down);
        //     
        // }
        // var player = GameObject.FindGameObjectWithTag("Player");

        if (minimapRef != null)
        {
            var playerCamera = minimapRef.GetComponentInChildren<Camera>();
            var playerPosition = minimapRef.transform.position;
            var playerRotation = minimapRef.transform.rotation;
            
            this.gameObject.transform.SetParent(minimapRef.transform);
            
            this.gameObject.transform.localPosition = new Vector3(0, 25.0f, 0);
            this.gameObject.transform.localRotation = Quaternion.LookRotation(Vector3.down);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
