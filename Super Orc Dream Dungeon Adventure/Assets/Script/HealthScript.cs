using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour 
{

	//public Image healthBar;
	public Slider healthBar;
	public float max_health = 100f;
	public float cur_health = 0f;
	public bool alive = true;

	//public float amount = -50f;

	// Use this for initialization
	void Start () 
	{
		healthBar.value = cur_health;
		cur_health = max_health;
		SetHealthBar ();
	}

	public void TakeDamage(float amount)
	{
		//checking if player is alive
		if(!alive)
		{
			return;
		}
		if(cur_health <= 0)
		{
			//kill player
			cur_health = 0;
			alive = false;
			gameObject.SetActive(false);
		}
		cur_health -= amount;
		SetHealthBar ();
	}

	void SetHealthBar () 
	{
	
		float my_health = cur_health / max_health;
		healthBar.transform.localScale = new Vector3 (Mathf.Clamp (my_health, 0f, 1f),healthBar.transform.localScale.y,healthBar.transform.localScale.z);
		

	}
}
