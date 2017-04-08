﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power: MonoBehaviour {

	public GameObject mechanicalSystem;
	public GameObject oxygenSystem;

	public Material redMaterial;
	public Material defaultMaterial;
	public GameObject[] wireColour = new GameObject[13];

	private int[] wiretimer = new int[13];
	private bool[] wirebroken = new bool[13];

	private bool[] wireStatus = new bool[13];
	private bool[] wireFlashing = new bool[13];
	private bool[] startFlashing = new bool[13];
	private bool hidden;
	private bool eventOccur;
	private int brokenTotal;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 13; i++){
			wirebroken[i] = false;
			wireStatus[i] = true;
			wireFlashing[i] = false;
			startFlashing[i] = false;
		}

		hidden = false;
		eventOccur = false;
		brokenTotal = 0;

		InvokeRepeating("GenerateEvent", 0f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		if(!wireStatus[0] && !startFlashing[0] && !wirebroken[0]){
			InvokeRepeating("flashWire1", 0f , 0.7f);
			startFlashing[0] = true;
		}

		if(!wireStatus[1] && !startFlashing[1] && !wirebroken[1]){
			InvokeRepeating("flashWire2", 0f , 0.7f);
			startFlashing[1] = true;
		}

		if(!wireStatus[2] && !startFlashing[2]&& !wirebroken[2]){
			InvokeRepeating("flashWire3", 0f , 0.7f);
			startFlashing[2] = true;
		}

		if(!wireStatus[3] && !startFlashing[3]&& !wirebroken[3]){
			InvokeRepeating("flashWire4", 0f , 0.7f);
			startFlashing[3] = true;
		}

		if(!wireStatus[4] && !startFlashing[4]&& !wirebroken[4]){
			InvokeRepeating("flashWire5", 0f , 0.7f);
			startFlashing[4] = true;
		}
		for(int i = 0; i < 13; i++){
			if (wireStatus[i]== false)
			{
				wiretimer[i] -= 1;
			}

			if(wiretimer[i] <= 0 && !wireStatus[i] && !wirebroken[i])
			{
				wireColour[i].GetComponent<MeshRenderer>().material = redMaterial;
				wirebroken[i] = true;
				startFlashing [i] = false;
				eventOccur = false;
				CancelInvoke ();
				InvokeRepeating("GenerateEvent", 0f, 2f);

				int random = Random.Range(0,2);
				if (random == 0) {
					oxygenSystem.GetComponent<Oxygen>().generateOutsideEvent ();
				} else {
					mechanicalSystem.GetComponent<Mechanical>().generateOutsideEvent ();
				}
			}
		}



	}

	void flashWire1(){
		if(wireFlashing[0]){
			wireColour[0].GetComponent<MeshRenderer>().material = redMaterial;
			wireFlashing[0] = false;
		}else{
			wireColour[0].GetComponent<MeshRenderer>().material = defaultMaterial;
			wireFlashing[0] = true;
		}
	}

	void flashWire2(){
		if(wireFlashing[1]){
			wireColour[1].GetComponent<MeshRenderer>().material = redMaterial;
			wireFlashing[1] = false;
		}else{
			wireColour[1].GetComponent<MeshRenderer>().material = defaultMaterial;
			wireFlashing[1] = true;
		}
	}

	void flashWire3(){
		if(wireFlashing[2]){
			wireColour[2].GetComponent<MeshRenderer>().material = redMaterial;
			wireFlashing[2] = false;
		}else{
			wireColour[2].GetComponent<MeshRenderer>().material = defaultMaterial;
			wireFlashing[2] = true;
		}
	}

	void flashWire4(){
		if(wireFlashing[3]){
			wireColour[3].GetComponent<MeshRenderer>().material = redMaterial;
			wireFlashing[3] = false;
		}else{
			wireColour[3].GetComponent<MeshRenderer>().material = defaultMaterial;
			wireFlashing[3] = true;
		}
	}

	void flashWire5(){
		if(wireFlashing[4]){
			wireColour[4].GetComponent<MeshRenderer>().material = redMaterial;
			wireFlashing[4] = false;
		}else{
			wireColour[4].GetComponent<MeshRenderer>().material = defaultMaterial;
			wireFlashing[4] = true;
		}
	}

	public void HidePower(){
		for(int i = 0; i < 13; i++){
			(wireColour[i].GetComponent<MeshRenderer>()).enabled = hidden;
		}

		if(!hidden){
			hidden = true;
		}else{
			hidden = false;
		}
	}

	void GenerateEvent(){
		int randomNum1 = Random.Range(0, 11);
		int randomNum2 = Random.Range(0, 5);

		if(randomNum1 == 1 && !eventOccur && !wirebroken[randomNum2]){
			wireStatus[randomNum2] = false;

			wiretimer[randomNum2]= 1000;
//			print ("Wire broken: " + wireColour[randomNum2].GetComponent<MeshRenderer>().name);
			eventOccur = true;
		}
	}

	public void FixPower(int i){
		if(wireStatus[i] == false && wirebroken[i] == false){
			wireStatus[i] = true;
			eventOccur = false;
			startFlashing[i] = false;
			wireColour[i].GetComponent<MeshRenderer>().material = defaultMaterial;
			CancelInvoke();
			InvokeRepeating("GenerateEvent", 0f, 2f);
		}
	}

	public bool getRoomEnable(){
		return (wireColour[0].GetComponent<MeshRenderer>()).enabled;
	}

	public bool getRoomStatus(int i){
		return wireStatus [i];
	}

	public int getBrokenAmount(){
		brokenTotal = 0;
		for(int i = 0; i < 5; i++){
			if(wirebroken[i]){
				brokenTotal++;
			}
		}

		return brokenTotal;
	}

	public void generateOutsideEvent(){
		int randomNum2 = Random.Range(0, 5);
		eventOccur = false;
		while (!eventOccur) {
			if (!eventOccur && !wirebroken [randomNum2]) {
				wireStatus [randomNum2] = false;

				wiretimer [randomNum2] = 1000;
//				print ("Wire broken: " + wireColour [randomNum2].GetComponent<MeshRenderer> ().name);
				eventOccur = true;
			}	
		}
	}
}
