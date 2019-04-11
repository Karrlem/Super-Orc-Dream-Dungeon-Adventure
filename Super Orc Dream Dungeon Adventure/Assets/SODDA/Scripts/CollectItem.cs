using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour {

    //Script on key or item, key icon is ui image under canvas
    //On key collider select is trigger and check it, and freeze y position

    public GameObject pickupEffect;


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
		if (plyr.gameObject.tag == "Player")
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);
		    Destroy(gameObject);
		    keyIcon.enabled = true;
		}
	}
}
