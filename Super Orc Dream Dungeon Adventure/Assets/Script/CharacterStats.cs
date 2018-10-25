using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public Stats damage;
    public Stats armor;
    public bool canAttack = false;


    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {

        /*
        if (canAttack == true)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Destroy(gameObject);
            }
        }
        if(Input.GetKeyDown(KeyCode.T))
		{
			TakeDamage(10);
		}*/
    }
    public void TakeDamage(int damage)
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

    public void CanAttack()
    {
        if (canAttack == true)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {

                TakeDamage(10);
            }
        }
    }

    void OnTriggerStay(Collider enmy)
    {
        if (enmy.gameObject.tag == "Enemy")
        {
            CanAttack();
            canAttack = true;
            Debug.Log("can attack");

        }
    }
}
