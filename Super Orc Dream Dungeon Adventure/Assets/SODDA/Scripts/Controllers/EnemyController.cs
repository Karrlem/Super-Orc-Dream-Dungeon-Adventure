using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour 
{
    static Animator anim;
	public float lookRadius = 10f;

	Transform target;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () 
	{
        anim = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
		//GameObject plyr = GameObject.FindGameObjectWithTag("Player");
		
		
	}

	void Update()
	{
		float distance = Vector3.Distance(target.position, transform.position);

		if(distance <= lookRadius)
		{
			agent.SetDestination(target.position);

			if(distance <= agent.stoppingDistance)
			{
                anim.SetBool("isIdle", false);
				//attack target
				//face target
				FaceTarget();
                anim.SetBool("isWalking", true);

			}
		}
	}
	

	void FaceTarget()
	{
        anim.SetBool("isIdle", false);
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,Time.deltaTime * 5f);
        anim.SetBool("isWalking", true);
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
}
