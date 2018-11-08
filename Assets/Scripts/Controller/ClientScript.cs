using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;

public class ClientScript : MonoBehaviour {

	static NetworkClient Cliente;
	string IPServer;
	[SerializeField] Text InputText;
	[SerializeField] Text DEBUGTXT;

	string GameState;
	// Use this for initialization
	void Start () {
		Cliente = new NetworkClient();
		GameState = "";
	}

	// Update is called once per frame
	void Update () {
//		Debug.Log (Cliente.isConnected);
	}

	private void WaitForMessage(NetworkMessage message){
		StringMessage msg = new StringMessage ();
		msg.value = message.ReadMessage<StringMessage> ().value;
		GameState = msg.value;
	}

	public string getGameState(){
		return GameState;
	}

	public void Conectar(){
		DEBUGTXT.text  ="CONECTAaa";
//		IPServer = InputText.text;

		//MANUAL INPUT
		IPServer = "192.168.0.40";
		Cliente.Connect (IPServer, 25000);
		Cliente.RegisterHandler (1, WaitForMessage);

	}

	public void SendMessage(StringMessage msg){
		if (Cliente.isConnected) {
			
			Cliente.Send(888, msg);
		}

	}
}
