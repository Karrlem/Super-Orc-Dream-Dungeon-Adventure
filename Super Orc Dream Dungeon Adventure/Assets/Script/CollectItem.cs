using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//Freeze Y Poistion on collecting object
	void OnTriggerEnter(Collider plyr)
	{
		if (plyr.gameObject.tag == "Player"){
		Debug.Log("key wee");
		Destroy(gameObject);
		
		}
	}
}
