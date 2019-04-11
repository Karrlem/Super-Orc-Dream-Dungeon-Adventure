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
    }

    // Update is called once per frame
    private void Update()
    {

            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Base_Attack");
            }
        
    }
}