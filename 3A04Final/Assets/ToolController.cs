using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolController : MonoBehaviour {

	public GameObject popup;
	public Image image;

	public Sprite flathead;
	public Sprite robertsonhead;
	public Sprite phillipshead;
	public Sprite torxhead;

	public Button flat;
	public Button robertson;
	public Button phillips;
	public Button torx;

	public GameObject powerSystem;
	public GameObject oxygenSystem;
	public GameObject mechanicalSystem;

	public bool result;

	string system;
	int number;

	public char tool; //tool toggle

	// Use this for initialization
	void Start () 
	{
		popup.SetActive(false); //initially pop not visible
	}

	void Update(){
		//**** temporary way of calling tool selection ***
		if(Input.GetKey ("x")){
			makeWindow ("Oxygen",2);
		}


		//******* Tool Listener *****************

		flat.onClick.AddListener(delegate{
			if(tool == 'f'){
				popup.SetActive(false);
				if (system.Equals("Power")){
					powerSystem.GetComponent<Power>().FixPower(number);
				}
				if (system.Equals("Oxygen")){
					oxygenSystem.GetComponent<Oxygen>().FixOxygen(number);
				}
				if (system.Equals("Mechanical")){
					mechanicalSystem.GetComponent<Mechanical>().FixMechanical(number);
				}
			}
			else{
				int randomNum = Random.Range(0,3);
				if (randomNum == 0) {
					oxygenSystem.GetComponent<Power> ().generateOutsideEvent ();
				} else if (randomNum == 1) {
					mechanicalSystem.GetComponent<Mechanical> ().generateOutsideEvent ();
				} else {
					powerSystem.GetComponent<Power> ().generateOutsideEvent ();
				}
			}
				});
		robertson.onClick.AddListener(delegate{
			if(tool == 'r'){
				popup.SetActive(false);
				if (system.Equals("Power")){
					powerSystem.GetComponent<Power>().FixPower(number);
				}
				if (system.Equals("Oxygen")){
					oxygenSystem.GetComponent<Oxygen>().FixOxygen(number);
				}
				if (system.Equals("Mechanical")){
					mechanicalSystem.GetComponent<Mechanical>().FixMechanical(number);
				}
			}
			else{
				int randomNum = Random.Range(0,3);
				if (randomNum == 0) {
					oxygenSystem.GetComponent<Power> ().generateOutsideEvent ();
				} else if (randomNum == 1) {
					mechanicalSystem.GetComponent<Mechanical> ().generateOutsideEvent ();
				} else {
					powerSystem.GetComponent<Power> ().generateOutsideEvent ();
				}
			}
		});
		phillips.onClick.AddListener(delegate{
			if(tool == 'p'){
				popup.SetActive(false);
				if (system.Equals("Power")){
					powerSystem.GetComponent<Power>().FixPower(number);
				}
				if (system.Equals("Oxygen")){
					oxygenSystem.GetComponent<Oxygen>().FixOxygen(number);
				}
				if (system.Equals("Mechanical")){
					mechanicalSystem.GetComponent<Mechanical>().FixMechanical(number);
				}
			}
			else{
				int randomNum = Random.Range(0,3);
				if (randomNum == 0) {
					oxygenSystem.GetComponent<Power> ().generateOutsideEvent ();
				} else if (randomNum == 1) {
					mechanicalSystem.GetComponent<Mechanical> ().generateOutsideEvent ();
				} else {
					powerSystem.GetComponent<Power> ().generateOutsideEvent ();
				}
			}
		});
		torx.onClick.AddListener(delegate{
			if(tool == 't'){
				popup.SetActive(false);
				if (system.Equals("Power")){
					powerSystem.GetComponent<Power>().FixPower(number);
				}
				if (system.Equals("Oxygen")){
					oxygenSystem.GetComponent<Oxygen>().FixOxygen(number);
				}
				if (system.Equals("Mechanical")){
					mechanicalSystem.GetComponent<Mechanical>().FixMechanical(number);
				}
			}
			else{
				int randomNum = Random.Range(0,3);
				if (randomNum == 0) {
					oxygenSystem.GetComponent<Power> ().generateOutsideEvent ();
				} else if (randomNum == 1) {
					mechanicalSystem.GetComponent<Mechanical> ().generateOutsideEvent ();
				} else {
					powerSystem.GetComponent<Power> ().generateOutsideEvent ();
				}
			}
		});

		//add here:

	}


	//********************  call to create popup window  ************************************

	public void makeWindow(string s, int i){	//returns true is button selected is correct

		system = s;
		number = i;

		StartCountdown.time = 2;
		System.Random rnd = new System.Random();
		int random = rnd.Next(1, 5); 
		if(random == 1){
			tool = 'f';
			image.sprite = flathead; //display flathead image
			popup.SetActive(true); //display popup
		}
		else if(random == 2){
			tool = 'r';
			image.sprite = robertsonhead; //display robertson image
			popup.SetActive(true); //display popup

		}
		else if(random == 3){
			tool = 'p';
			image.sprite = phillipshead; //display phillips image
			popup.SetActive(true); //display popup

		}
		else if (random == 4) {
			tool = 't';
			image.sprite = torxhead; //display torx image
			popup.SetActive(true); //display popup

		} 
	}		

	public void makeProblem(){
		int random = Random.Range(0,3);
		if (random == 0) {
			oxygenSystem.GetComponent<Oxygen> ().generateOutsideEvent ();
		} else if (random == 1) {
			mechanicalSystem.GetComponent<Mechanical> ().generateOutsideEvent ();
		} else {
			powerSystem.GetComponent<Power> ().generateOutsideEvent ();
		}
	}

}
