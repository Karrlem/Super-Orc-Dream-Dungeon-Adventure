using UnityEngine;

public class DamageScript : MonoBehaviour {


	//Script on Enemy
	
	float damage =50f;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider plyr)
	{
		if (plyr.gameObject.tag == "Player"){
		Debug.Log("ouchies");
		plyr.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
		//damage -= 10;
		}
	}
}
