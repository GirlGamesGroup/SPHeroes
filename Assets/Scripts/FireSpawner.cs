using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour {
	private Vector3[] posVect;
	private bool[] hasFire;
	private bool CreatedAFire;

	[SerializeField] protected GameObject Fire;
	[SerializeField] protected int LimitWindows;
	[SerializeField] protected int PeriodOf = 1;
	private int WindowsOn;

	void Start () {


		posVect = new Vector3[9];
		hasFire = new bool[9];
		CreatedAFire = false;
		posVect [0] = new Vector3 (-3.8877f,0.6329f , 0f);
		posVect [1] = new Vector3 (-3.675f, 0.6329f, 0f);
		posVect [2] = new Vector3 (-3.465f, 0.6329f, 0f);
		posVect [3] = new Vector3 (-3.8877f, 0.242f, 0f);
		posVect [4] = new Vector3 (-3.675f, 0.242f, 0f);
		posVect [5] = new Vector3 (-3.465f, 0.242f, 0f);
		posVect [6] = new Vector3 (-3.8877f, -0.148f, 0f);
		posVect [7] = new Vector3 (-3.675f, -0.148f, 0f);
		posVect [8] = new Vector3 (-3.465f, -0.148f, 0f);

		for (int i = 0; i < 9; i++) {
			hasFire [i] = false;
		}
	}

	private void OnEnable () {
		
		InvokeRepeating ("SpawnFire", 1, PeriodOf);
	}

	public Vector3[] getPosVect(){
		return posVect;
	}

	private void SpawnFire() {
		int nPositions = posVect.Length;
		int randomPos;

		do {
			
			randomPos = Random.Range (0, nPositions);
			if (!hasFire [randomPos]) {
				Instantiate (Fire, posVect[randomPos], Quaternion.identity);
				hasFire [randomPos] = true;
				CreatedAFire = true;
				WindowsOn++;
			} else {
				CreatedAFire = false;
			}

		} while(!CreatedAFire  && WindowsOn < LimitWindows);
			
	}

	public bool[] getHasFire(){
		return hasFire;
	}

	public void killFire (int i){
		hasFire [i] = false;
		WindowsOn--;
	}
		
	void OnDisable () {
		CancelInvoke ();
	}
}
