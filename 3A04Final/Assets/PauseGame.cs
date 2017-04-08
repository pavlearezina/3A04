using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

	public GameObject pausepopup;
	public GameObject canvas;

	void Start () 
	{
		pausepopup.SetActive(false); //initially pop not visible
	}

	public void pause(){
		pausepopup.SetActive(true); //show popup
		Oxygen.pause = false;
		Time.timeScale = 0.0f;
	}

	public void resume(){
		Time.timeScale = 1.0f;
		Oxygen.pause = true;
		pausepopup.SetActive(false); //hide popup
	}

	public void exit(){
		Time.timeScale = 1.0f;
		Destroy(GameObject.Find("GameStart"));
		SceneManager.LoadScene ("Launch");
	}
		

}
