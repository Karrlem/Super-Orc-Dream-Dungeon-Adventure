using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour 
{

	//Script on pressure plate and place door into gameobject door

	[SerializeField]
	GameObject door;

	void OnTriggerStay()
	{
        //Door up Position
		door.transform.position = new Vector3(-29, 12, 20);
		}
		 void OnTriggerExit()
		{
            //Door Down position
			door.transform.position = new Vector3(-29, 6, 20);
			Debug.Log("Down");
		} 
}
