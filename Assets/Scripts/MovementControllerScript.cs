using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovementControllerScript : MonoBehaviour {

//	private Vector3 pos1;
//	private Vector3 pos2; 
//	private Vector3 pos3; 
//	private Vector3 pos4; 
//	private Vector3 pos5; 
//	private Vector3 pos6; 
//	private Vector3 pos7; 
//	private Vector3 pos8; 
//	private Vector3 pos9; 
//	private Vector3[] posVect;
//	private NewType[] DirArray;
	[SerializeField] protected GameObject Pointer;
	[SerializeField] protected GameControllerScript GCS;
	[SerializeField] protected Text debugTXT;
	private Vector3 temp1;
	private Vector3 temp2; 

	//INPUT FROM CONTROLLER
	private string PressedButton;
	//


	[SerializeField] protected float UpLimit;
	[SerializeField] protected float DownLimit;
	[SerializeField] protected float LeftLimit;
	[SerializeField] protected float RightLimit;

	[SerializeField] protected float DistUpDown;
	[SerializeField] protected float DistLeftRight;

	[SerializeField] protected Vector3 StartPosition;

	// Use this for initialization
	void Start () {
//		//DEMO INICIALIZADORES:
//		//START POS FOR DEMO
//		StartPosition = new Vector3 (1.84f , 1.721f, -6.12f);
//
//		//LIMITS FOR DEMO
//		UpLimit = 4.1f;
//		DownLimit = -0.6f;
//		LeftLimit = -1.2f;
//		RightLimit = 4.95f;
//
//		//DISTANCE UP AND DOWN FOR DEMO
//		DistUpDown = 2.38f;
//		DistLeftRight = 3.11f;
//
//		/////////////////////////////

		temp1 = new Vector3 (0, DistUpDown, 0);
		temp2 = new Vector3 (DistLeftRight, 0, 0);
		Pointer.transform.position = StartPosition;

	}


	void Update () {


//		Debug.Log ("llego al server el boton: "+ PressedButton);
//WORKS WITH WASD
//		if (Input.GetKeyDown (KeyCode.W)) {
//
//			if(Pointer.transform.position.y < UpLimit ){
//				
//				Pointer.transform.position += temp1;
//			}
//
//		} else if (Input.GetKeyDown (KeyCode.A)) {
//			if(Pointer.transform.position.x > LeftLimit ){
//				Pointer.transform.position -= temp2;
//			}
//		} else if (Input.GetKeyDown (KeyCode.S)) { 
//			if(Pointer.transform.position.y > DownLimit ){
//				Pointer.transform.position -= temp1;
//			}
//		} else if (Input.GetKeyDown (KeyCode.D)) {
//			if(Pointer.transform.position.x < RightLimit ){
//				Pointer.transform.position += temp2;
//			}
//		}



			

	}

	public void Move(){
		PressedButton = GCS.getPressedButton();
		switch(PressedButton){

		case "W": //GO UP
			if(Pointer.transform.position.y < UpLimit ){
				Pointer.transform.position += temp1;
			}
			break;
		case "S": //GO DOWN
			if(Pointer.transform.position.y > DownLimit ){
				Pointer.transform.position -= temp1;
			}
			break;
		case "A"://GO LEFT
			if(Pointer.transform.position.x > LeftLimit ){
				Pointer.transform.position -= temp2;
			}
			break;
		case "D": //GO RIGHT
			if(Pointer.transform.position.x < RightLimit ){
				Pointer.transform.position += temp2;
			}
			break;
		default:
			break;
		}
	}
}
