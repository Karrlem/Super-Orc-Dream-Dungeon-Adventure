using UnityEngine;

public class DamageScript : MonoBehaviour {

	
	float damage = 50f;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("ouchies");
		other.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
	}
}
