using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	float timeLeft = 120;
	[SerializeField] protected Text countText;
	private GameControllerScript GCS;

	// Use this for initialization
	void Start () {
		GameObject controller = GameObject.FindGameObjectWithTag ("GameController");
		GCS = controller.GetComponent<GameControllerScript> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		int min = Mathf.FloorToInt(timeLeft / 60);
		int sec = Mathf.FloorToInt(timeLeft % 60);

		if (min == 1 && sec == 0) {
			OneMinLeft ();
		}

		if (min == 0 && sec == 0) {
			TimeOver ();
		}
		countText.text = min.ToString("00") + ":" + sec.ToString("00");
		timeLeft -= Time.deltaTime;
	}

	void OneMinLeft (){
		countText.color = Color.red;
	}

	void TimeOver(){
		GCS.setWon ();
	}

	// 2MINUTES: 100/120
	// SUBSTRACT CURRENT X FROM SCALE BY 100/120 EACH SECOND
}
