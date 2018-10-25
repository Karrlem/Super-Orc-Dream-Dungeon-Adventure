using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public Stats damage;
    public Stats armor;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            TakeDamage(10);
        }
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
            Destroy(gameObject);
        }
    }
    public virtual void Die()
    {
        //Die in some way
        //This method is meant to be overwritten
        Debug.Log(transform.name + "Died");
    }

}



/*{
    //from the chaaracter stats script
	public override void Die()
	{
		base.Die();
        //detroys the enemy
		Destroy(gameObject);
	}
}
*/