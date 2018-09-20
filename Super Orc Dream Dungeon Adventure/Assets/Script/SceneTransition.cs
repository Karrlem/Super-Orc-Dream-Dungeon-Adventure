using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour 
{
	public Animator tranisitionAnim;
	public string sceneName;

	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(LoadScene());
		}
	}
	IEnumerator LoadScene()
	{
		tranisitionAnim.SetTrigger("End");
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene(sceneName);
	}
}
