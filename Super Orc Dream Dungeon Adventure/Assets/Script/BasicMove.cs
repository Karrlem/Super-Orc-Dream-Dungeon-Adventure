using UnityEngine;

public class BasicMove : MonoBehaviour {

	//Place on player and add rigidbody to player

	public float speed = 20;
	private Rigidbody rb;

	void Start(){
		rb = GetComponent <Rigidbody> ();
	}

	void Update(){
		float hMove = Input.GetAxis ("Horizontal");
		float vMove = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (hMove, 0f, vMove);

		rb.AddForce (movement * speed);
	}
}
