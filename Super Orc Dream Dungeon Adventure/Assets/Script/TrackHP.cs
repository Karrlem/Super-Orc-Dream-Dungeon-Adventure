using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackHP : MonoBehaviour {

	public static int health = 100;
    public Slider healthColor;


    // Use this for initialization
    void Start () {
        healthColor = GetComponent <Slider> ();
        healthColor.value = health;
    }

	
    public void ReduceHealth(){
        if (health > 0) {
        health = health - 10;
        healthColor.value = health;
        }
        else if(health <= 0){
			Destroy(GameObject.FindWithTag("Player"));
		}
    }

    public void IncreaseHealth(){
		if (health < 100) {
		health += 10;
		healthColor.value = health;
		}
	}

    

	/* void Update (){
	if(Input.GetKeyDown (KeyCode.A)){
		ReduceHealth();

		}
	} */

   /*  void OnTriggerEnter(Collision col){
  if (GameObject.FindWithTag("Enemy")){ // check if it's the player, if you want
    //Destroy(GameObject.FindWithTag("Player"));
  }
} */

/* void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.name == "Cube")
        {
           // Destroy(col.gameObject);
        }
    } */

}
