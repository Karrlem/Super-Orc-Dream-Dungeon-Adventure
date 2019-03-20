/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public Stats damage;
    public Stats armor;
    private bool canAttack = false;

    //Label player script
    CharacterStats characterStats;

    void Awake()
    {
        currentHealth = maxHealth;

        //Calls player script
        characterStats = GameObject.FindWithTag ("Player").GetComponent<CharacterStats>();
    }

    void Update()
    {
        
    }
    public void EnemyTakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + "takes" + damage + "damage");

        if (currentHealth <= 0)
        {
            Die();
            
        }
    }
    public virtual void Die()
    {
        //Die in some way
        //This method is meant to be overwritten
        Debug.Log(transform.name + "Died");
    }



 void CanAttack()
    {
        if (canAttack == true)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                AttackTarget();

            }
        }
    }

    void OnTriggerStay(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            CanAttack();
            canAttack = true;
            //Debug.Log("can attack");

        }
    }

    //Fuction attacks enemy then enemy takes damage from the input
    void AttackTarget(){
        characterStats.PlayerTakeDamage(10);
    }
    
}*/