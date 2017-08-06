using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform playerTransform;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        //Vector3 newPosition = playerTransform.position;
        //newPosition = newPosition + offset;
        //transform.position = newPosition;

        //transform.localRotation = playerTransform.rotation;

        ////transform.LookAt(playerTransform);
        ////Vector3 newPosition = playerTransform.position;

        //////newPosition = newPosition /*+ playerTransform.forward*/;
        ////transform.position = newPosition;
        ////transform.Translate(offset);
        //////transform.Translate(Vector3.up * offset.y);
    }
}
