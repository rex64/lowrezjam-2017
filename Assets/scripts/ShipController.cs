using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public float speed;
    public float gravity;
    public float turning;

    public Transform playerModelTransform;


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
        bool isSteering = false;

        Vector3 _force = new Vector3();

        if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            transform.position = hit.point;
            transform.position = transform.position + (transform.up * 2.0f);

        } else
        {
            GetComponent<Rigidbody>().AddForce(Vector3.down * gravity, ForceMode.Acceleration);
        }


        if (Input.GetKey(KeyCode.A) || Input.GetAxisRaw("Horizontal") == -1.0f)
        {
            GetComponent<Rigidbody>().MoveRotation(transform.rotation * Quaternion.Euler(0.0f, -1.0f, 0.0f));
            //GetComponent<Rigidbody>().AddTorque(Vector3.right * 10.0f);
            turning = Mathf.Max(-40.0f, turning - 1.0f);


        }
        else if (Input.GetKey(KeyCode.D) || Input.GetAxisRaw("Horizontal") == 1.0f)
        {
            GetComponent<Rigidbody>().MoveRotation(transform.rotation * Quaternion.Euler(0.0f, 1.0f, 0.0f));
            //GetComponent<Rigidbody>().AddTorque(Vector3.left * 10.0f);
            turning = Mathf.Min(40.0f, turning + 1.0f);

        }
        else
        {
            float iotti = 4.0f;

            if (turning < 0.0f)
            {
                turning = turning + iotti > 0.0f ? 0.0f : turning + iotti;
            }
            else if (turning > 0.0f)
            {
                turning = turning - iotti < 0.0f ? 0.0f : turning - iotti;

            }
            //turning -= 1.0f;


            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        }

        if (Input.GetKey(KeyCode.Space))
        {
            float speed2 = isSteering ? speed / 4 : speed;
            _force = _force + transform.forward * speed2;

        }

        //print(_force);
        GetComponent<Rigidbody>().AddForce(_force);
        playerModelTransform.localRotation = Quaternion.Euler(
            playerModelTransform.localRotation.eulerAngles.x,
            turning,
            playerModelTransform.localRotation.eulerAngles.z
        );



    }
}
