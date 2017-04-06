using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour {

	public bool oxygen;
	public bool mechanical;
	public bool power;
	
	// Use this for initialization
	void Start () {
	}

	public void loadGame(){
		oxygen = GameObject.Find ("OxygenSelect").GetComponent<Toggle>().isOn;
		mechanical = GameObject.Find ("MechanicalSelect").GetComponent<Toggle>().isOn;
		power = GameObject.Find ("PowerSelect").GetComponent<Toggle>().isOn;

		DontDestroyOnLoad(GameObject.Find("GameStart"));
		SceneManager.LoadScene ("Ship");
	}
	public void loadMainScreen(){
		GameObject.Find("GameStart").GetComponent<MainScreen>().oxygen = false;
		GameObject.Find("GameStart").GetComponent<MainScreen>().mechanical = false;
		GameObject.Find("GameStart").GetComponent<MainScreen>().power = false;
		Destroy(GameObject.Find("GameStart"));


		SceneManager.LoadScene ("Launch");
	}
}
