using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().MoveRotation(transform.rotation * Quaternion.Euler(0.0f, -1.0f, 0.0f));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().MoveRotation(transform.rotation * Quaternion.Euler(0.0f, 1.0f, 0.0f));
        }
    }
}
