using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCountdown : MonoBehaviour
{
	public static int time;
    private bool yes;
    public string timeDisp;

	public Text startCounter;
	public GameObject popup;

    void Start()
    {
        yes = true;
    }

    void Update()
    {
        
		if (yes && time > -1 )
        {
            StartCoroutine(timeDelay());
            
            startCounter.text = time.ToString();
            time--;
        }
        if (time == -1)
        {
            startCounter.text = "0";
			waitFunction ();
			popup.SetActive (false);
			//add fail selection

//			GameObject.Find ("ToolController").GetComponent<ToolController> ().makeProblem ();
        }
    }

    IEnumerator timeDelay()
    {
        yes = false;
        yield return new WaitForSeconds(1);
        yes = true;
        
    }

	IEnumerator waitFunction(){
		yield return new WaitForSeconds (2);
	}
}
