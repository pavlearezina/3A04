using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour {

	public Text[] roomText = new Text[5];
	public SpriteRenderer[] roomColour = new SpriteRenderer[5];
	private bool[] roomStatus = new bool[5]; 
	private double[] roomPercentage = new double[5];

	private float[] colourG = new float[5];
	private float[] colourR = new float[5];

	private bool eventOccur;

	private bool hidden;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 5; i++){
			roomStatus[i] = true;
			roomPercentage[i] = 1.0;
			roomText[i].text = "" + roomPercentage[i].ToString("P"); 
		}
		InvokeRepeating("GenerateEvent", 5f, 0.1f);
		eventOccur = false;
		hidden = false;
	}
	
	// Update is called once per frame
	void Update () {
			
		for(int i = 0; i < 5; i++){

			if(!roomStatus[i] && roomPercentage[i] > 0){
				roomPercentage[i] -= 0.001;
			}

			if(roomPercentage[i] < 0){
				roomPercentage[i] = 0;
			}

			roomText[i].text = "" + roomPercentage[i].ToString("P");
			colourG[i] = (float)(roomPercentage[i]);
			colourR[i] = (float)(0f + (1f - roomPercentage[i]));
			roomColour[i].color = new Color(colourR[i], colourG[i], 0f, 1f);

		}
			


	}

	void GenerateEvent(){
		int randomNum1 = Random.Range(0, 10);
		int randomNum2 = Random.Range(0, 4);

		if(randomNum1 == 1 && !eventOccur){
			roomStatus[randomNum2] = false;
			eventOccur = true;
		}

	}

	void FixOxygen(int i){
		roomStatus[i] = true;
		eventOccur = true;
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
}
