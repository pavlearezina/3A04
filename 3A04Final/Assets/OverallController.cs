using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OverallController : MonoBehaviour {

	public Slider SpaceShipSlider;  //reference for slider

	// Use this for initialization
	void Start () {
		InvokeRepeating("UpdateShipSlider", 5f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
//		if(SpaceShipSlider.value == 1){
//			SceneManager.LoadScene("WINEER")
//		}
	}

	void UpdateShipSlider(){
		SpaceShipSlider.value +=.05f; //rate a which slider moves
	}
}
