﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public GameObject Death;
    //Collision to check if hit by Sword
    private void OnTriggerEnter(Collider other)
     {
         if(other.gameObject.tag == "Sword")
         {
            //Debug.Log("Killed" + name);
            Instantiate(Death, transform.position, transform.rotation);
            gameObject.SetActive(false);
            //Destroy (gameObject);
        }
     }
}
