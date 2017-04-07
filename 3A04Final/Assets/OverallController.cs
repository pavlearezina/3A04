using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverallController : MonoBehaviour {

	public Slider SpaceShipSlider;  //reference for slider

	public GameObject[] oxygenObject = new GameObject[3];
	public GameObject[] mechObject = new GameObject[3];
	public GameObject[] powerObject = new GameObject[3];

	public GameObject oxygenSystem;
	public GameObject mechanicalSystem;
	public GameObject powerSystem;

	private Oxygen oxygen;
	private Power power;
	private Mechanical mechanical;

	// Use this for initialization
	void Start () {
		MainScreen ms = GameObject.Find("GameStart").GetComponent<MainScreen>();
		if (ms.oxygen == false) {
			for (int i = 0; i < oxygenObject.Length; i++) {
				Destroy (oxygenObject [i]);
			}
		}

		if (ms.mechanical == false) {
			for (int i = 0; i < oxygenObject.Length; i++) {
				Destroy (mechObject [i]);
			}
		}

		if (ms.power == false) {
			for (int i = 0; i < oxygenObject.Length; i++) {
				Destroy (powerObject [i]);
			}
		}
	

		InvokeRepeating("UpdateShipSlider", 0f, 0.1f);
	}

	// Update is called once per frame
	void Update () {
		bool oxygenEnabled;
		bool powerEnabled;
		bool mechEnabled;

		if (Input.touchCount != 0) {
			Touch touch = Input.GetTouch (0);
			Ray ray = Camera.main.ScreenPointToRay (touch.position);
			var pos = Camera.main.ScreenToWorldPoint (touch.position);
			RaycastHit hit;

			RectTransform[] oxygenClicks = null;
			RectTransform[] mechanicalClicks = null;
			RectTransform[] powerClicks = null;

			try{
				oxygen = GameObject.Find("OxygenSystem").GetComponent<Oxygen>();
				oxygenClicks = oxygenObject [1].GetComponentsInChildren<RectTransform>();
				oxygenEnabled = true;
			}
			catch{
				oxygenEnabled = false;
			}
			try{
				mechanical = GameObject.Find("MechnicalSystem").GetComponent<Mechanical>();
				mechanicalClicks = mechObject [1].GetComponentsInChildren<RectTransform>();
				mechEnabled = true;
			}
			catch{
				mechEnabled = false;
			}

			try{
				power = GameObject.Find("PowerSystem").GetComponent<Power>();
				//				print(powerObject[1].GetComponents<RectTransform>);
				powerClicks = powerObject [1].GetComponentsInChildren<RectTransform>();
				powerEnabled = true;
			}
			catch{
				powerEnabled = false;
			}
			if (Physics.Raycast (ray, out hit) && touch.phase == TouchPhase.Began) {
				if (oxygenEnabled) {
					for (int i = 1; i < oxygenClicks.Length; i += 2) {
						if (oxygen.getRoomEnable ()) {
							if (RectTransformUtility.RectangleContainsScreenPoint (oxygenClicks [i], pos)) {
								print ("Touched Oxygen " + (i / 2));
								//debug.text = "Touched Oxygen " + (i / 2 + 1);
							}
						}
					}
				}
				if (mechEnabled) {
					for (int i = 0; i < mechanicalClicks.Length; i++) {
						if (mechanical.getRoomEnable ()) {
							if (RectTransformUtility.RectangleContainsScreenPoint (mechanicalClicks [i], pos)) {
								print ("Touched Door " + i);
								//debug.text = "Touched Door " + (i + 1);
							}
						}
					}
				}
				if (powerEnabled) {
					for (int i = 0; i < powerClicks.Length; i++) {
						if (power.getRoomEnable ()) {
							if (RectTransformUtility.RectangleContainsScreenPoint (powerClicks [i], pos)) {
								print ("Touched " + powerClicks[i].name);
								//debug.text = "Touched Wire " + (i + 1);
							}
						}
					}
				}
			}
		}

	}

	void UpdateShipSlider(){
		SpaceShipSlider.value +=.05f; //rate a which slider moves
		if (SpaceShipSlider.value == 1)
			SceneManager.LoadScene("GameWon");
	}

}
