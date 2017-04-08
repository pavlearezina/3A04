using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour {

	public GameObject mechanicalSystem;
	public GameObject powerSystem;

	public static bool pause;

	public Text[] roomText = new Text[5];
	public SpriteRenderer[] roomColour = new SpriteRenderer[5];
	private bool[] roomStatus = new bool[5]; 
	private double[] roomPercentage = new double[5];

	private bool[] roombroken = new bool[5];
	private double[] roomtimers = new double[5];

	private float[] colourG = new float[5];
	private float[] colourR = new float[5];

	private bool eventOccur;

	private int brokenTotal;
	private bool hidden;

	// Use this for initialization
	void Start () {
		pause = true;
		for(int i = 0; i < 5; i++){
			roomStatus[i] = true;
			roombroken[i] = false;
			roomPercentage[i] = 1.0;
			roomText[i].text = "" + roomPercentage[i].ToString("P"); 
		}
		InvokeRepeating("GenerateEvent", 0f, 0.8f);
		eventOccur = false;
		hidden = false;

		brokenTotal = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (pause) {
			for (int i = 0; i < 5; i++) {

				if (!roomStatus [i] && roomPercentage [i] > 0) {
					roomPercentage [i] -= 0.001;
					roomtimers [i] -= 1;
				}

				if (roomPercentage [i] < 0) {
					roomPercentage [i] = 0;
				}

				if (roomPercentage [i] >= 1) {
					roomPercentage [i] = 1;
				}

				if (!roomStatus [i] && roomtimers [i] <= 0 && !roombroken [i]) {
					roomText [i].text = "FAIL";
					roomColour [i].color = new Color (1f, 0f, 0f, 1f);
					roombroken [i] = true;

					eventOccur = false;

					int random = Random.Range (0, 2);
					if (random == 0) {
						mechanicalSystem.GetComponent<Mechanical> ().generateOutsideEvent ();
					} else {
						powerSystem.GetComponent<Power> ().generateOutsideEvent ();
					}
				} else {
					roomText [i].text = "" + roomPercentage [i].ToString ("P");
					colourG [i] = (float)(roomPercentage [i]);
					colourR [i] = (float)(0f + (1f - roomPercentage [i]));
					roomColour [i].color = new Color (colourR [i], colourG [i], 0f, 1f);
				}

			}
		}

	}

	void GenerateEvent(){
		int randomNum1 = Random.Range(0, 11);
		int randomNum2 = Random.Range(0, 5);

		if(randomNum1 == 1 && !eventOccur && !roombroken[randomNum2]){
			roomStatus[randomNum2] = false;
			roomtimers[randomNum2] = 1000;

//			print ("Oxygen broken: " + randomNum2);

			eventOccur = true;
		}

	}

	public void FixOxygen(int i){
		if(roomStatus[i] == false && roombroken[i] == false){
			roomStatus[i] = true;
			roomPercentage [i] = 1;
			roomText[i].text = "" + roomPercentage[i].ToString("P");
			roomColour[i].color = new Color(0f, 1f, 0f, 1f);
			eventOccur = false;
		}
	}

	public void HideOxygen(){

		for(int i = 0; i < 5; i++){
			roomText[i].enabled = hidden;
			roomColour[i].enabled = hidden;

		}

		if(!hidden){
			hidden = true;
		}else{
			hidden = false;
		}
	}

	public bool getRoomEnable(){
		return roomColour[0].enabled;
	}

	public bool getRoomStatus(int i){
		return roomStatus [i];
	}

	public void generateOutsideEvent(){
		int randomNum2 = Random.Range(0, 5);
		eventOccur = false;
		while (!eventOccur) {
			if (!eventOccur && !roombroken[randomNum2]) {
				roomStatus [randomNum2] = false;

				roomtimers [randomNum2] = 1000;
//				print ("Oxygen broken: " + randomNum2);
				eventOccur = true;
			}	
		}
	}

	public int getBrokenAmount(){
		brokenTotal = 0;
		for(int i = 0; i < 5; i++){
			if(roombroken[i]){
				brokenTotal++;
			}
		}

		return brokenTotal;
	}
}
