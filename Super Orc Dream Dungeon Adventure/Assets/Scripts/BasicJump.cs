using UnityEngine;

public class BasicJump : MonoBehaviour {

	//Place on player and add rigidbody to player

	public float jump = 10;

		void Update (){
		if(Input.GetKeyDown (KeyCode.Space)){
		if(transform.position.y <= 1.0f ){
			GetComponent<Rigidbody> ().AddForce (Vector3.up * jump);
			}
		}
	}
}