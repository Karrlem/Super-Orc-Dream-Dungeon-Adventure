using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private Animator m_animator;
    private GameObject[] myEnenmies;
    public GameObject objToDestory;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myEnenmies = GameObject.FindGameObjectsWithTag("Enemy");


        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attacking");
            m_animator.SetTrigger("attack");
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Sword")
        {
            Debug.Log("Hit");
            Destroy(objToDestory);
        }
    }
}
