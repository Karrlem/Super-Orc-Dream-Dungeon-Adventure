using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour 
{
    public int health;
    Animator anim;
	public float lookRadius = 10f;

    private float dazedTime;
    public float startDazedTime;
    public float speed;

	Transform target;
	NavMeshAgent agent;
    public GameObject deathEffect;
    public GameObject bloodEffect;
    public GameObject thisEnemy;

    public GameObject enemyDeath;


    //public float knockBackForce;
    //public float knockBackTime;
    //private float knockBackCounter;

    // Use this for initialization
    void Start () 
	{
        //speed = GetComponent<NavMeshAgent>().speed;
        anim = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
        //GameObject plyr = GameObject.FindGameObjectWithTag("Player");
    
	}

	void Update()
	{
		float distance = Vector3.Distance(target.position, transform.position);

        if(dazedTime <= 0)
        {
            agent.speed = 3f;
        }
        else
        {
            agent.speed = 0f;
            dazedTime -= Time.deltaTime;
        }

		if(distance <= lookRadius)
		{
			agent.SetDestination(target.position);
            anim.SetBool("IsWalking", true);

            if (distance <= agent.stoppingDistance)
			{
                
                //attack target
                //face target
                FaceTarget();
                

			}
        }
        else
        {
            agent.velocity = Vector3.zero;
            anim.SetBool("IsWalking", false);
        }

        if(health <= 0)
        {
            Destroy(gameObject);
            Instantiate(enemyDeath,thisEnemy.transform.position, thisEnemy.transform.rotation);
            Instantiate(deathEffect, thisEnemy.transform.position, thisEnemy.transform.rotation);
        }
	}
	

	void FaceTarget()
	{
        
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,Time.deltaTime * 5f);
        
    }
	
	void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}

	void OnCollisionExit (Collision other)
 {
     if (other.gameObject.tag == "Player")
     {
            //transform.position = Vector3.zero;
            Vector3 position = transform.position;
            agent.SetDestination(position);
     }
        
 }
    public void TakeDamage(int damage)
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        dazedTime = startDazedTime;
        health -= damage;
        Debug.Log("damage taken !");
    }
}
