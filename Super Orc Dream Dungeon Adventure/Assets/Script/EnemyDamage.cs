using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour {

    public TrackHP healthColor;
    

     GameObject player;
     

    // Use this for initialization
    void Start () {

        healthColor = GameObject.FindGameObjectWithTag ("Health").GetComponent <TrackHP> ();
        healthColor.ReduceHealth();
    }

    void Awake ()
    {
        
    }

    void OnCollisionEnter (Collision col) {
        
        if (col.gameObject.tag == "Enemy") {
			healthColor.ReduceHealth();

		}
    }

	
    

/* void OnTriggerEnter (Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            ReduceHealth();
        }
    } */


	
    

/* void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.name == "Cube")
        {
            Destroy(col.gameObject);
           //ReduceHealth();
        }
    } */
}