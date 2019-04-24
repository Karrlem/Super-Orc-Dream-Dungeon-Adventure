using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuController : MonoBehaviour
{
    public string startScene;
    // Start is called before the first frame update
    public void NewGame()
    {
        SceneManager.LoadScene(startScene,LoadSceneMode.Single);
    }

    // Update is called once per frame
    public void ExitGame()
    {
        Application.Quit();
    }
}
