using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour {


[SerializeField] private Image keyIcon;

	// Use this for initialization
	void Start () {
		keyIcon.enabled = false;
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
		keyIcon.enabled = true;
		}
	}
}
