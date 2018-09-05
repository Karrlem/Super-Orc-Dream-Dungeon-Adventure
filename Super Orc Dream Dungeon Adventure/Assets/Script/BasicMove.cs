using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour {

	public float speed = 50;
	private Rigidbody rb;

	void Start(){
		rb = GetComponent <Rigidbody> ();
	}

	void FixedUpdate(){
		float hMove = Input.GetAxis ("Horizontal");
		float vMove = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (hMove, 0f, vMove);

		rb.AddForce (movement * speed);
	}
}
