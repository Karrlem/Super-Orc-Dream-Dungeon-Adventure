using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public Stats damage;
    public Stats armor;
    private bool canAttack = false;

    //Label enemy script
    EnemyStats enemyStats;
    

     


    void Awake()
    {
        currentHealth = maxHealth;

        //Calls enemy script
        enemyStats = GameObject.FindWithTag ("Enemy").GetComponent<EnemyStats>();
    }

    void Update()
    {

    }
    public void PlayerTakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + "takes" + damage + "damage");

        if (currentHealth <= 0)
        {
            Die();
            Destroy(gameObject);
        }
    }
    void Die()
    {
        //Die in some way
        //This method is meant to be overwritten
        Debug.Log(transform.name + "Died");
        
    }

    void CanAttack()
    {
        if (canAttack == true)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                AttackTarget();

            }
        }
    }

    void OnTriggerStay(Collider enmy)
    {
        if (enmy.gameObject.tag == "Enemy")
        {
            CanAttack();
            canAttack = true;
            //Debug.Log("can attack");

        }
    }

    //Fuction attacks enemy then enemy takes damage from the input
    void AttackTarget(){
        enemyStats.EnemyTakeDamage(20);
    }
}
