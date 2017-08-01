using UnityEngine;
using System.Collections;
using System;

public class PlayerControl : MonoBehaviour
{

    Vector3 starPos;

    public float speed;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        starPos = transform.position;
    }

    public void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Quad") {

            Reset();
        }
    }

    private void Reset()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.rotation = Quaternion.identity;
        transform.position = starPos;

    }
}
