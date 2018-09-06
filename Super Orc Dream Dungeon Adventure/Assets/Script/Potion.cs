using UnityEngine;

public class Potion : MonoBehaviour {

	private TrackHP healthbar;

	// Use this for initialization
	void Start () {
		healthbar = GameObject.FindGameObjectWithTag ("Health").GetComponent <TrackHP> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			healthbar.IncreaseHealth ();
		}
	}
}
