using UnityEngine;

public class BasicMove : MonoBehaviour {

	//Place on player and add rigidbody to player

	public float speed = 20;
    public float jump = 10;
    private Rigidbody rb;

	void Start(){
		rb = GetComponent <Rigidbody> ();
	}

    void Update()
    {
        //Walking
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hMove, 0f, vMove);

        rb.AddForce(movement * speed);

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.y <= 1.0f)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * jump);
            }
        }
    }
}
