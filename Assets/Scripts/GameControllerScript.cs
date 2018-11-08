using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameControllerScript : MonoBehaviour {

	private int DeadWindows;
	private bool GameOver;
	private bool GameWon;
	private bool tempBool;
	private bool tempBool2;
	private string PressedButton;
	[SerializeField] Text DebugTxt;

	//IMPORTANT
	[SerializeField] protected ServidorScript SC;
	//



	[SerializeField] protected GameObject MainScreen;
	[SerializeField] protected GameObject GameScreen;
	[SerializeField] protected GameObject LoseScreen;
	[SerializeField] protected GameObject WinScreen;

	private string CurrentStateOfGame;

	public bool isShooting;

	// Use this for initialization
	void Start () {
		MainScreen.SetActive(false);
		GameScreen.SetActive(false);
		LoseScreen.SetActive(false);
		WinScreen.SetActive(false);
		PressedButton = " ";
	
		GameOver = false;
		GameWon = false;
		tempBool = false;
		tempBool2 = false;
		DeadWindows = 0;
		IsShowingMainScreen ();
	}

	private void IsShowingMainScreen(){
//		debugTXT.text = "entro ms";
		CurrentStateOfGame = "ShowingMS";
		LoseScreen.SetActive(false);
		WinScreen.SetActive(false);
		GameScreen.SetActive (false);
		MainScreen.SetActive (true);
	}

	private void IsPlayingGame(){
		GameOver = false;
		GameWon = false;
		DeadWindows = 0;
		CurrentStateOfGame = "Playing";
		MainScreen.SetActive(false);
		LoseScreen.SetActive(false);
		WinScreen.SetActive(false);
		GameScreen.SetActive (true);
	}

	private void HasLostGame(){
//		SC.TellGameStatus ("L");
//
		CurrentStateOfGame = "Lost";

		MainScreen.SetActive(false);
		LoseScreen.SetActive(true);
		WinScreen.SetActive(false);
		GameScreen.SetActive (false);
	}

public void HasWonGame(){
//		SC.TellGameStatus ("W");
//
		CurrentStateOfGame = "Won";
		MainScreen.SetActive(false);
		LoseScreen.SetActive(false);
		WinScreen.SetActive(true);
		GameScreen.SetActive (false);
	}

	public void SetPressedButton(string s){
		PressedButton = s;
	}

	public string getPressedButton(){
		return PressedButton;
	}

	public void setWon(){
		GameWon = true;
	}
	
	// Update is called once per frame
	void Update () {
//
//		DebugTxt.txt;
		if (DeadWindows == 2 && !GameOver) {
			Debug.Log ("PERDISTE");
			GameOver = true;
			HasLostGame ();
		}


		if (getPressedButton() == "X" ){
			tempBool = true;
			IsPlayingGame ();
		}

		if (GameOver && getPressedButton() == "C") {
			IsPlayingGame ();
		}

		if (GameWon && getPressedButton() == "Z") {
			IsShowingMainScreen ();
		}

//		if (CurrentStateOfGame == "Playing" && GameOver) {
//			HasLostGame ();
//		}
//
//		if (CurrentStateOfGame == "Playing" && GameWon) {
//			HasWonGame ();
//		}
//
//
//
//		if (CurrentStateOfGame == "Won" && getPressedButton() == "Z") {
//			IsShowingMainScreen ();
//		}

		isShooting = false;
	}

	public void AddDeadWindow(){
		DeadWindows++;
		Debug.Log("WINDOW DIED");
	}

	private void ShootOnce (){
		isShooting = true;
	}
//	private void LoseGame(){
//		FireSpawnerObject.SetActive (false);
//		MovementObject.SetActive (false);
//		WindowControllerObject.SetActive (false);
//		Timer.SetActive (false);
//	}
//
//	public void WinGame(){
//		FireSpawnerObject.SetActive (false);
//		MovementObject.SetActive (false);
//		WindowControllerObject.SetActive (false);
//			Timer.SetActive (false);
//	}

	public bool getGameover(){
		return GameOver;
	}

	public bool getGameWon(){
		return GameWon;
	}
}
