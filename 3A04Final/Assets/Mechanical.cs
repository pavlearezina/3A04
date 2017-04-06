using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mechanical : MonoBehaviour {

	public Material Grey;
	public Material Red;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Mechanical").GetComponent<Toggle> ().isOn == true) { //if toggle selected
			GetComponent<Renderer> ().material = Red; //make doors red
		}
		if (GameObject.Find ("Mechanical").GetComponent<Toggle> ().isOn == false) { //if toggle not selected
			GetComponent<Renderer> ().material = Grey; //make doors invisible
		}
	}
}
