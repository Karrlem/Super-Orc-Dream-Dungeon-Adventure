using UnityEngine;

public class Potion : MonoBehaviour
{

    //Script on Potion or healing portion

    float damage = -50f;
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            Debug.Log("Yay");
            plyr.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
            //damage -= 10;
        }
    }
}
