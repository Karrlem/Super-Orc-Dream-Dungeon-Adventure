using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    //Collision to check if hit by Sword
    private void OnTriggerEnter(Collider other)
     {
         if(other.gameObject.tag == "Sword")
         {
            Debug.Log("Killed" + name);
             Destroy (this.gameObject);
         }
     }
}
