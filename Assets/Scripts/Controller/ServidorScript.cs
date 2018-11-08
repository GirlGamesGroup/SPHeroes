using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;

public class ServidorScript : MonoBehaviour {
	string IPServidor;
	[SerializeField] Text IPTextoEnPantalla;

	[SerializeField] GameControllerScript GCS;
	static NetworkClient Cliente;
	[SerializeField] MovementControllerScript MCS;
	int CuantasVecesRecibe;
	void OnGUI(){
		IPServidor = Network.player.ipAddress;
		IPTextoEnPantalla.text = IPServidor;


	}

	// Use this for initialization
	void Start () {
		NetworkServer.Listen (25000);
		NetworkServer.RegisterHandler (888, ServerReceiveMessage);
		CuantasVecesRecibe = 0;
	}

	void Init(NetworkClient client){
		Cliente = client;
	}

	private void ServerReceiveMessage(NetworkMessage message){

//		CuantasVecesRecibe++;
		StringMessage msg = new StringMessage ();
		msg.value = message.ReadMessage<StringMessage> ().value;
		GCS.SetPressedButton (msg.value);
		//SEND MOVEMENT
		MCS.Move ();
		//SEND SHOOT
		if (msg.value == "L") {
			GCS.isShooting = true;
		}
			
//		if (GCS.getGameover ()) {
//			if (msg.value == "C") {
//				GCS.isShooting = true;
//			}
//			//RESTART GAME
//		}
//
//		if (GCS.getGameWon ()) {
//			if (msg.value == "Z") {
//				GCS.isShooting = true;
//			}
		}





	public void TellGameStatus(string status){
		if (NetworkServer.connections.Count > 0) {
			StringMessage msg = new StringMessage ();
			msg.value = status;
			NetworkServer.SendToClient (1, 1, msg);
		}
	}


	// Update is called once per frame
	void Update () {
				
	}
}
