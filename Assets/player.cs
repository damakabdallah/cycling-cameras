using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]


public class player : MonoBehaviour {
    public float speed = 3.5f;
    public float jumpForce = 500f;
    public float rotationSpeed = 40f;
    public bool canJump = false;
    public Rigidbody rb;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.position += transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
            transform.RotateAround(transform.position,Vector3.up,rotationSpeed*Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.RotateAround(transform.position, Vector3.up, -rotationSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space)&& canJump)
        {
            
            canJump = false;
            rb.AddForce(0, jumpForce, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "floor")
            canJump = true;
    }
}
