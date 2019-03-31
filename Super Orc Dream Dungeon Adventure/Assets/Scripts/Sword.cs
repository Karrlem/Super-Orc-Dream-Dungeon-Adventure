using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log("Attacking");
    }

    // Update is called once per frame
    private void Update()
    {

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Attacking");
                animator.SetTrigger("Base_Attack");
            }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sword")
        {
            Debug.Log("hi");
            Destroy(gameObject);

        }
    }
}