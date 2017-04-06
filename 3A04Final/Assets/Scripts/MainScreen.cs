using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	public void loadGame(){
		SceneManager.LoadScene ("Ship");
	}
	public void loadMainScreen(){
		SceneManager.LoadScene ("Launch");
	}
}
