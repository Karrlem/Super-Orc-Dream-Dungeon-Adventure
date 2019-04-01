using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    //public Rigidbody theRB;
    public float jumpForce;
    public CharacterController controller;
    private float minRotation = -90;
    private float maxRotation = 90;

    private Animator m_animator;


    private Vector3 moveDirection;
    public float gravityScale;

    float pushPower = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        //theRB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        //m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Jump");
                moveDirection.y = jumpForce;
            }
        }

       /* if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attacking");
            m_animator.SetTrigger("attack");
        }
        */
        moveDirection.y = moveDirection.y + Physics.gravity.y * gravityScale *Time.deltaTime;
        controller.Move(moveDirection* Time.deltaTime);

        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

        Vector3 currentRotation = transform.localRotation.eulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, minRotation, maxRotation);
        transform.localRotation = Quaternion.Euler(currentRotation);

        //theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        /* if(Input.GetButtonDown("Jump"))
         {
             theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
         }*/
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

}
