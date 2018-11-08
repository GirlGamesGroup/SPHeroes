using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireScript : MonoBehaviour {
	private FireSpawner FS;
	private WindowScript WS;
	private GameControllerScript GCS;

	private bool isShooting;

	private Vector3[] posVect;
	private int currentPos;

	private int StateOfFire;

	[SerializeField] protected Sprite fire1;
	[SerializeField] protected Sprite fire2;
	[SerializeField] protected Sprite fire3;

	[SerializeField] protected float timeBetweenStates;

	private SpriteRenderer spriteRenderer;

	private Text DebugText;

	void Awake(){
		WS = GameObject.FindGameObjectWithTag("WindowController").GetComponent<WindowScript> ();
		GCS = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControllerScript> ();
		DebugText =  GameObject.FindGameObjectWithTag ("DebugTXT").GetComponent<Text>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = fire1;
	}

	// Use this for initialization
	void Start () {
		StateOfFire = 0;

		FS =GameObject.FindGameObjectWithTag("FireSpawnerObj").GetComponent<FireSpawner> ();

		posVect = FS.getPosVect ();
		for (int i = 0; i < 9; i++) {
			if(gameObject.transform.position == posVect[i]){
				currentPos = i;
			}
		}
		isShooting = false;

		StartCoroutine (LifeCycle(1));
	}
	
	IEnumerator LifeCycle(int StateFire){
		StateOfFire = StateFire;
		yield return new WaitForSeconds(timeBetweenStates);
		if (StateOfFire == 1) {
			spriteRenderer.sprite = fire2;
			StateOfFire = 2;
			yield return new WaitForSeconds(timeBetweenStates);
		}

		if (StateOfFire == 2) {
			spriteRenderer.sprite = fire3;
			StateOfFire = 3;
			yield return new WaitForSeconds(timeBetweenStates);
		}

		WS.ChangeWindow (currentPos);
		GCS.AddDeadWindow ();
		Destroy(gameObject);

	}

	void OnTriggerStay(Collider other) {

//			//		WORKS WITH KEYBOARD
//			if (Input.GetKeyDown (KeyCode.L)) {
//				isShooting = true;
//				ExtinguishFire ();
//			}
		//SECOND VERSION, SHOOTING WAY TOO MUCH
//		if (isShooting)
//			return;
//					if (GCS.getPressedButton() == "L") {
//						StartCoroutine (CooldownBoton ());
//						Debug.Log ("shoot");
//						ExtinguishFire ();
//					}
		if(GCS.isShooting){
			ExtinguishFire ();
		}

	}

	void Update(){
		if (GCS.getGameover ()) {
			Destroy(gameObject);
		}
	}


	void ExtinguishFire(){

		switch (StateOfFire) {
		case 3:
				StopCoroutine ("LifeCycle");
				Debug.Log ("fire state 3");
				StateOfFire--;
				spriteRenderer.sprite = fire2;
			isShooting = false;
				StartCoroutine (LifeCycle (2));
				break;

		case 2:	StopCoroutine ("LifeCycle");
				Debug.Log ("fire state 2");
				StateOfFire--;
				spriteRenderer.sprite = fire1;
			isShooting = false;
				StartCoroutine (LifeCycle (1));
				break;
		case 1:Debug.Log ("fire state 1");
				FS.killFire (currentPos);
				
				Destroy(gameObject);
				break;
		}

	}




}
