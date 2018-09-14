using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour 
{
	[SerializeField]
	GameObject door;

	void OnTriggerStay()
	{
		door.transform.position = new Vector3(0, 8, 4);
		}
		 void OnTriggerExit()
		{
			door.transform.position = new Vector3(0, 3, 4);
			Debug.Log("Down");
		} 
}
