using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    //private Animator animator;
    public GameObject enemy;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider enemy)
    {
        enemy.gameObject.SetActive(false);

    }
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {

            /*if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Base_Attack");
            }*/
        
    }
}