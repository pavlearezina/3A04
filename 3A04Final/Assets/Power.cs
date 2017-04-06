using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power: MonoBehaviour {

	public Material Grey;
	public Material Yellow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Power").GetComponent<Toggle> ().isOn == true) { //if toggle selected
			GetComponent<Renderer> ().material = Yellow; //make wires yellow
		}
		if (GameObject.Find ("Power").GetComponent<Toggle> ().isOn == false) { //if toggle not selected
			GetComponent<Renderer> ().material = Grey; //make wires invisible
		}
	}
}
