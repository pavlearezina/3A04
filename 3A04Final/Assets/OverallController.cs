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

		if (Input.touchCount != 0) {
			Touch touch = Input.GetTouch (0);
			Ray ray = Camera.main.ScreenPointToRay (touch.position);
			var pos = Camera.main.ScreenToWorldPoint (touch.position);
			RaycastHit hit;

			Oxygen oxygen = GameObject.Find("OxygenSystem").GetComponent<Oxygen>();

//			if (Physics.Raycast (ray, out hit) && touch.phase == TouchPhase.Began) {
//				if (oxygen.getRoomEnable()){
//					if (RectTransformUtility.RectangleContainsScreenPoint (oxygen1, pos)) {
//						debug.text = "Touched Oxygen 1";
//					}
//					if (RectTransformUtility.RectangleContainsScreenPoint (oxygen2, pos)) {
//						debug.text = "Touched Oxygen 2";
//					}
//					if (RectTransformUtility.RectangleContainsScreenPoint (oxygen3, pos)) {
//						debug.text = "Touched Oxygen 3";
//					}
//					if (RectTransformUtility.RectangleContainsScreenPoint (oxygen4, pos)) {
//						debug.text = "Touched Oxygen 4";
//					}
//					if (RectTransformUtility.RectangleContainsScreenPoint (oxygen5, pos)) {
//						debug.text = "Touched Oxygen 5";
//					}
//				}
//			}
		}

		//		if(SpaceShipSlider.value == 1){
		//			SceneManager.LoadScene("WINEER")
		//		}
	}

	void UpdateShipSlider(){
		SpaceShipSlider.value +=.05f; //rate a which slider moves
		if (SpaceShipSlider.value == 1)
			SceneManager.LoadScene("GameWon");
	}

}
