using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public static int health = 100;
    public Slider healthBar;


    // Use this for initialization
    void Start () {
        healthBar = GetComponent <Slider> ();
        healthBar.value = health;
    }

	
    void ReduceHealth(){
        health = health - 10;
        healthBar.value = health;
    }

	void Update (){
	if(Input.GetKeyDown (KeyCode.A)){
		ReduceHealth();

		}
	}

}