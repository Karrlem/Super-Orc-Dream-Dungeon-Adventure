﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
     {
         if(other.gameObject.tag == "Sword")
         {
             Debug.Log("Attacking");
             Destroy (gameObject);
         }
     }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
