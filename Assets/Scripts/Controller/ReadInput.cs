using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour {

	[SerializeField] ClientScript CS;

	[SerializeField] GameObject ConnectScreen;
	[SerializeField] GameObject PlayGameScreen;
	[SerializeField] GameObject ControllerScreen;

	//WILL BE IMPLEMENTED WITH SERVER -> CLIENT COMMUNICATION
//	[SerializeField] GameObject RestartScreen;
//	[SerializeField] GameObject WinScreen;


	private bool puedeOprimir;
	private bool hasWonGame;
	private bool hasLostGame;
	//Z FOR SHOWING MAIN MENU
	//X FOR STARTING GAME
	//C FOR RESTARTING

	void Start () {
		ConnectScreen.SetActive(true);
		PlayGameScreen.SetActive(false);
		ControllerScreen.SetActive(false);
//		RestartScreen.SetActive(false);
//		WinScreen.SetActive (false);

		hasWonGame = false;
		hasLostGame = false;
		puedeOprimir = true;
	}
	
	// Update is called once per frame


//IMPLEMENT WITH SERVER CLIENT COMUNICATION
	//	void Update () {
//		if (CS.getGameState () == "W" && !hasWonGame) {
//			hasWonGame = true;
//			WonGame ();
//		}
//
//		if (CS.getGameState () == "L" && !hasLostGame) {
//			hasWonGame = true;
//			ResetGame ();
//		}
//	}

	public void ConnectButton(){
		ConnectScreen.SetActive(false);
		CS.Conectar ();
		StringMessage sm = new StringMessage ();
		sm.value ="Z";
		CS.SendMessage (sm);
		PlayGameScreen.SetActive(true);
	}

	public void GoUp(){
		if (!puedeOprimir)
			return;
		StartCoroutine (CooldownBoton ());
		StringMessage sm = new StringMessage ();
		sm.value ="W";
		CS.SendMessage (sm);
	}

	public void StartGame(){
		PlayGameScreen.SetActive(false);
		StringMessage sm = new StringMessage ();
		sm.value ="X";
		CS.SendMessage (sm);
		ControllerScreen.SetActive(true);

	}

	public void ResetGame(){
		
		//IMPLEMENTED WITH SERVER -> CLIENT COMMUNICATION
		//receives a msg from server when he loses to change controller to reset
//		ControllerScreen.SetActive(false);
//		RestartScreen.SetActive(true);
		//reloads play scene

		if (!puedeOprimir)
			return;
		StartCoroutine (CooldownBoton ());
		StringMessage sm = new StringMessage ();
		sm.value ="C";
		CS.SendMessage (sm);
	}

//	public void PressRestartButton(){
//		RestartScreen.SetActive(false);
//		StringMessage sm = new StringMessage ();
//		sm.value ="C";
//		CS.SendMessage (sm);
//		DebugText.text = sm.value;
//		ControllerScreen.SetActive(true);
//	}

//	public void WonGame(){
//		//receives a msg from server when he wins to change controller to play again
//		ControllerScreen.SetActive(false);
//		WinScreen.SetActive(true);
//		//goes back to main menu
//	}

	public void PressMenuButton(){
		if (!puedeOprimir)
			return;
		StartCoroutine (CooldownBoton ());
		StringMessage sm = new StringMessage ();
		sm.value ="Z";
		CS.SendMessage (sm);
	}

	public void GoDown(){
		if (!puedeOprimir)
			return;
		StartCoroutine (CooldownBoton ());
		StringMessage sm = new StringMessage ();
		sm.value ="S";
		CS.SendMessage (sm);


	}

	public void GoLeft(){
		if (!puedeOprimir)
			return;
		StartCoroutine (CooldownBoton ());
		StringMessage sm = new StringMessage ();
		sm.value ="A";
		CS.SendMessage (sm);	

	}

	public void GoRight(){
		if (!puedeOprimir)
			return;
		StartCoroutine (CooldownBoton ());
		StringMessage sm = new StringMessage ();
		sm.value ="D";
		CS.SendMessage (sm);	

	}

	public void Shoot(){
		if (!puedeOprimir)
			return;
		StartCoroutine (CooldownBoton ());
		StringMessage sm = new StringMessage ();
		sm.value ="L";
		CS.SendMessage (sm);


	}

	private IEnumerator CooldownBoton()
	{
		puedeOprimir = false;
		yield return new WaitForSeconds (1/2);
		puedeOprimir = true;
	}
}
