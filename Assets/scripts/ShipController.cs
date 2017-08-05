using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public float speed;
    public float gravity;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		//if (Input.GetKey(KeyCode.Space))
  //      {
  //          //GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
  //          GetComponent<Rigidbody>().AddForce(transform.forward * 10.0f);
  //      }

  //      if (Input.GetKey(KeyCode.A))
  //      {
  //          GetComponent<Rigidbody>().MoveRotation(transform.rotation * Quaternion.Euler(0.0f, -1.0f, 0.0f));
  //      }
  //      else if (Input.GetKey(KeyCode.D))
  //      {
  //          GetComponent<Rigidbody>().MoveRotation(transform.rotation * Quaternion.Euler(0.0f, 1.0f, 0.0f));
  //      }
    }

    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {
            print(hit.distance);
            //transform.up = hit.normal;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

            transform.position = hit.point;

            transform.position = transform.position + (transform.up * 2.0f); 

            //Vector3 lookAt = Vector3.Cross(-hit.normal, transform.right);
            //// reverse it if it is down.
            //lookAt = lookAt.y < 0 ? -lookAt : lookAt;
            //// look at the hit's relative up, using the normal as the up vector
            //transform.rotation = Quaternion.LookRotation(hit.point + lookAt, hit.normal);


        } else
        {
            GetComponent<Rigidbody>().AddForce(Vector3.down * gravity, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            //GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().MoveRotation(transform.rotation * Quaternion.Euler(0.0f, -1.0f, 0.0f));
            //GetComponent<Rigidbody>().add(-transform.right * 10.0f);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().MoveRotation(transform.rotation * Quaternion.Euler(0.0f, 1.0f, 0.0f));
            //GetComponent<Rigidbody>().AddForce(transform.right * 10.0f);

        }

    }
}
