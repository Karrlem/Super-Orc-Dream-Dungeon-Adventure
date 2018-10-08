using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    public string Name;
    public string InteractText = "Press f to interact";

    public virtual void OnInteract()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    /*Gina
    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            Debug.Log("key wee");
            Destroy(gameObject);
            
        }
    }
    */
}
