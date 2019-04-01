using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour 
{

	//Script on player, make slider and place asset on health bar

	//[SerializeField] private Image my_health;
	//public Image fillAmount;
//	GameObject Player;
	public Slider healthBar;
	
	public string mainMenuScene;
	public float max_health = 100f;
	public float cur_health = 0f;
	public bool alive = true;

	public float amount = 50f;
	
	//float damage = 50f;

	//public float damage = 50f;

	// Use this for initialization
	void Start () 
	{
		healthBar = GetComponent<Slider>();
		//my_health = GetComponent<Image>();
		//fillAmount = GetComponent<Image>();
		cur_health = max_health;
		healthBar.value = CalculateHealth();
		//SetHealthBar ();
		//InvokeRepeating("DoDamage", 1f, 5f);
	}

	void Update (){
		//healthBar.fillAmount = cur_health / max_health;
		//DoDamage();
		CalculateHealth();
		//TakeDamage(50f);
		
	}


	void DoDamage(){
		TakeDamage(50f);
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
//			Destroy (Player);
			
			//brings to main menu. can be replaced with game over scene if wanted
			//SceneManager.LoadScene(mainMenuScene);
		}
		//amount = 50f;
		cur_health -= amount;
		//SetHealthBar ();
		healthBar.value = CalculateHealth();
		DoDamage();
		
	}

	/* void SetHealthBar () 
	{
	
		float my_health = cur_health / max_health;
		//redGoodness.fillAmount = my_health;
		//healthBar.transform.localScale = new Vector3 (Mathf.Clamp (my_health, 0f, 1f),healthBar.transform.localScale.y,healthBar.transform.localScale.z);
		

	} */

	float CalculateHealth(){
		return cur_health / max_health;
	}
}
