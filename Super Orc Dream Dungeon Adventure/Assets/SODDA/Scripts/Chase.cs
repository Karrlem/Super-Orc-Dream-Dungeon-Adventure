    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.position , this.transform.position) < 10)
        {
            Vector3 direction = player.position = this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 1f * Time.deltaTime);

            if(direction.magnitude > 5)
            {
                this.transform.Translate(0, 0, 0.05f);
            }
        }
    }
}
