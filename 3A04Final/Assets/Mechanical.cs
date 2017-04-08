using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mechanical : MonoBehaviour {

	public GameObject oxygenSystem;
	public GameObject powerSystem;

	public Material redMaterial;
	public Material defaultMaterial;
	public GameObject[] doorColour = new GameObject[4];


	private int[] doortimer = new int[4];
	private bool[] doorbroken = new bool[4];

	private bool[] doorStatus = new bool[4];
	private bool[] doorFlashing = new bool[4];
	private bool[] startFlashing = new bool[4];
	private bool hidden;
	private bool eventOccur;

	private int brokenTotal;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 4; i++){
			doorbroken[i] = false;
			doorStatus[i] = true;
			doorFlashing[i] = false;
			startFlashing[i] = false;
		}

		hidden = false;
		eventOccur = false;
		brokenTotal = 0;

		InvokeRepeating("GenerateEvent", 0f, 3.6f);
	}
	
	// Update is called once per frame
	void Update () {

		if(!doorStatus[0] && !startFlashing[0]&& !doorbroken[0]){
			InvokeRepeating("flashDoor1", 0f , 0.7f);
			startFlashing[0] = true;
		}

		if(!doorStatus[1] && !startFlashing[1]&& !doorbroken[1]){
			InvokeRepeating("flashDoor2", 0f , 0.7f);
			startFlashing[1] = true;
		}

		if(!doorStatus[2] && !startFlashing[2]&& !doorbroken[2]){
			InvokeRepeating("flashDoor3", 0f , 0.7f);
			startFlashing[2] = true;
		}

		if(!doorStatus[3] && !startFlashing[3]&& !doorbroken[3]){
			InvokeRepeating("flashDoor4", 0f , 0.7f);
			startFlashing[3] = true;
		}

		for(int i = 0; i < 4; i++){
			if (doorStatus[i]== false)
			{
				doortimer[i] -= 1;
			}

			if(doortimer[i] <= 0 && !doorStatus[i] && !doorbroken[i])
			{
				doorColour[i].GetComponent<MeshRenderer>().material = redMaterial;
				doorbroken[i] = true;
				startFlashing [i] = false;
				eventOccur = false;
				CancelInvoke ();
				InvokeRepeating("GenerateEvent", 0f, 3.6f);

				int random = Random.Range(0,2);
				if (random == 0) {
					oxygenSystem.GetComponent<Oxygen>().generateOutsideEvent ();
				} else {
					powerSystem.GetComponent<Power>().generateOutsideEvent ();
				}
			}
		}




			
	}

	void GenerateEvent(){
		int randomNum1 = Random.Range(0, 11);
		int randomNum2 = Random.Range(0, 4);

		if(randomNum1 == 1 && !eventOccur && !doorbroken[randomNum2]){
			doorStatus[randomNum2] = false;

//			print ("Door broken: " + randomNum2);

			doortimer[randomNum2]= 1000;
			eventOccur = true;
		}

	}

	void flashDoor1(){
		if(doorFlashing[0]){
			doorColour[0].GetComponent<MeshRenderer>().material = redMaterial;
			doorFlashing[0] = false;
		}else{
			doorColour[0].GetComponent<MeshRenderer>().material = defaultMaterial;
			doorFlashing[0] = true;
		}
	}

	void flashDoor2(){
		if(doorFlashing[1]){
			doorColour[1].GetComponent<MeshRenderer>().material = redMaterial;
			doorFlashing[1] = false;
		}else{
			doorColour[1].GetComponent<MeshRenderer>().material = defaultMaterial;
			doorFlashing[1] = true;
		}
	}

	void flashDoor3(){
		if(doorFlashing[2]){
			doorColour[2].GetComponent<MeshRenderer>().material = redMaterial;
			doorFlashing[2] = false;
		}else{
			doorColour[2].GetComponent<MeshRenderer>().material = defaultMaterial;
			doorFlashing[2] = true;
		}
	}

	void flashDoor4(){
		if(doorFlashing[3]){
			doorColour[3].GetComponent<MeshRenderer>().material = redMaterial;
			doorFlashing[3] = false;
		}else{
			doorColour[3].GetComponent<MeshRenderer>().material = defaultMaterial;
			doorFlashing[3] = true;
		}
	}

	public void HideMechanical(){
		for(int i = 0; i < 4; i++){
			(doorColour[i].GetComponent<MeshRenderer>()).enabled = hidden;
		}

		if(!hidden){
			hidden = true;
		}else{
			hidden = false;
		}
	}

	public void FixMechanical(int i){
		if(doorStatus[i] == false && doorbroken[i] == false){
			doorStatus[i] = true;
			eventOccur = false;
			startFlashing[i] = false;
			doorColour[i].GetComponent<MeshRenderer>().material = defaultMaterial;
			CancelInvoke();
			InvokeRepeating("GenerateEvent", 0f, 3.6f);
		}
	}

	public bool getRoomEnable(){
		return (doorColour[0].GetComponent<MeshRenderer>()).enabled;
	}

	public bool getRoomStatus(int i){
		return doorStatus [i];
	}

	public int getBrokenAmount(){
		brokenTotal = 0;
		for(int i = 0; i < 4; i++){
			if(doorbroken[i]){
				brokenTotal++;
			}
		}

		return brokenTotal;
	}

	public void generateOutsideEvent(){
		int randomNum2 = Random.Range(0, 4);
		eventOccur = false;
		while (!eventOccur) {
			if (!eventOccur && !doorbroken [randomNum2]) {
				doorStatus [randomNum2] = false;

				doortimer [randomNum2] = 1000;
//				print ("door broken: " + randomNum2);
				eventOccur = true;
			}	
		}
	}
}
