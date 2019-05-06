using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public CharacterController controller;
    public float gravityScale;

    //private float minRotation = -90;
    //private float maxRotation = 90;

    public Animator anim;
    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerModel;

    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;


    private Vector3 moveDirection;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
  

    float pushPower = 2.0f;
    private object physics3D;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
        {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

        if (knockBackCounter <= 0)
        { 
            float yStore = moveDirection.y;
            moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
            moveDirection = moveDirection.normalized * moveSpeed;
            moveDirection.y = yStore;

        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        } 
        moveDirection.y = moveDirection.y + Physics.gravity.y * gravityScale *Time.deltaTime;
        controller.Move(moveDirection* Time.deltaTime);

        //Move the player in different directions
        if(Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y , 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Vertical") + Mathf.Abs(Input.GetAxis("Horizontal"))));
        //transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

        //Vector3 currentRotation = transform.localRotation.eulerAngles;
        //currentRotation.x = Mathf.Clamp(currentRotation.x, minRotation, maxRotation);
        // transform.localRotation = Quaternion.Euler(currentRotation);

        if (Input.GetButtonDown("Fire1"))
        {
            Collider[] enemiesToDamage = Physics.OverlapSphere(attackPos.position, attackRange, whatIsEnemies);
            for(int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<EnemyController>().TakeDamage(damage);
            }
            anim.SetTrigger("attack");


        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    //player can push objects
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * pushPower;
    }


    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        //direction = new Vector3(1f, 1f, 1f);

        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Pit")
        {
            GetComponent<HealthManager>().currentHealth -= 1;
        }

    }
}
