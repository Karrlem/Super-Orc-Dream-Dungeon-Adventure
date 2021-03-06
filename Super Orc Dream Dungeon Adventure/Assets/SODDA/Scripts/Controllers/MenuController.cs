﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {


	//Place onto Canvas of the pause menu!!!
	//In order for the menu to switch scenes you have to go to File> Build Settings > Open Scene and it will open the scene you're working on

	public string mainMenuScene;
	public GameObject pauseMenu;
	public bool isPaused;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			
			if(isPaused){
				isPaused = false;
				pauseMenu.SetActive(false);
				Time.timeScale = 1f;
			}

			else {
				isPaused = true;
				pauseMenu.SetActive(true);
				Time.timeScale = 0f;
			}
		}
	}

	public void ResumeGame (){
		isPaused = false;
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
	}

	public void ReturnToMain (){
		Time.timeScale = 1f;
		SceneManager.LoadScene(mainMenuScene);
	}
}
