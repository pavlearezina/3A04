using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolController : MonoBehaviour {

	public GameObject popup;

	// Use this for initialization
	void Start () 
	{
		popup.SetActive(false);
	}

	void Update(){
		if(Input.GetKey ("x")){
			popup.SetActive(true);	//show window
		}
	}
		


		
	public void flatselected (){	
		popup.SetActive(false); //close popup
		//send to overall that flat was selected
	}

	public void robertsonselected (){	
		popup.SetActive(false); //close popup
		//send to overall that robertson was selected
	}

	public void phillipsselected (){	
		popup.SetActive(false); //close popup
		//send to overall that phillips was selected
	}
	public void torxselected (){	
		popup.SetActive(false); //close popup
		//send to overall that torx was selected
	}
		
		

}
