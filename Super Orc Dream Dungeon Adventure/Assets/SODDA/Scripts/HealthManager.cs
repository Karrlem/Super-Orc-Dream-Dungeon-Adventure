using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider healthBar;
    public Text hP;

    public int maxHealth;
    public int currentHealth;

    public PlayerController thePlayer;

    public float invincibilityLength;
    private float invincibilityCounter;

    public Renderer playerRenderer;
    private float flashCounter;
    public float flashlegth = 0.1f;

    private bool isRespawning;
    private Vector3 respawnPoint;
    public float respawnLength;
    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthBar.value = CalculateHealth();
        //thePlayer = FindObjectOfType<PlayerController>();

        respawnPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        hP.text = "HP: " + currentHealth;
        if(invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCounter = flashlegth;
            }

            if(invincibilityCounter <= 0)
            {
                playerRenderer.enabled = true;
            }
        }
    }
    public void HurtPlayer(int damage, Vector3 direction)
    {
        if(invincibilityCounter <= 0)
        {

       
            currentHealth -= damage;
            healthBar.value = CalculateHealth();

            if(currentHealth <= 0)
            {
                Respawn();
            }
                else
                { 

                    thePlayer.Knockback(direction);

                    invincibilityCounter = invincibilityLength;

                    playerRenderer.enabled = false;
                    
                flashCounter = flashlegth;
                }
         }
     }

    public void Respawn()
    {
        //thePlayer.transform.position = respawnPoint;
        //currentHealth = maxHealth;
        if (!isRespawning)
        {
            StartCoroutine("RespawnCo");
        }
    }
        public IEnumerator RespawnCo()
    {
        isRespawning = true;
        thePlayer.gameObject.SetActive(false);
        Instantiate(deathEffect, thePlayer.transform.position, thePlayer.transform.rotation);

        yield return new WaitForSeconds(respawnLength);
        isRespawning = false;


        thePlayer.gameObject.SetActive(true);
        thePlayer.transform.position = respawnPoint;
        currentHealth = maxHealth;

        invincibilityCounter = invincibilityLength;
        playerRenderer.enabled = false;
        flashCounter = flashlegth;
    }

    float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }
    public void HealPlayer(int healAmount)
    {
        //makes sure the health doest go above max limit.
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
