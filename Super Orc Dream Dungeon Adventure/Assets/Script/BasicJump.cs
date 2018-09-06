using UnityEngine;

public class BasicJump : MonoBehaviour {

	public float jump = 10;

		void Update (){
		if(Input.GetKeyDown (KeyCode.Space)){
		if(transform.position.y <= 1.0f ){
			GetComponent<Rigidbody> ().AddForce (Vector3.up * jump);
			}
		}
	}
}