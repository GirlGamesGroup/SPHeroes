using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour {
	private Vector3 EndPos;
	[SerializeField] protected float speed;
	private float step;

	void Awake(){
		step = speed * Time.deltaTime;

		EndPos = transform.position;
		EndPos.y +=3f;
//
//		StartCoroutine ("MovingDown");
	}

//	IEnumerator MovingDown(){
//
//				int i = 0;
//				while (transform.position != EndPos) {
//					transform.position = Vector3.MoveTowards (transform.position, EndPos, step);
//					yield return new WaitForEndOfFrame ();
//					i++;
//
//				}
//	}

	void Update(){
		transform.position = Vector3.MoveTowards (transform.position, EndPos, step);
		if (transform.position == EndPos) {
			Vector3 Temp;
			Temp = EndPos;
			Temp.y -= 3f;
			transform.position = Temp;
		}
	}
}
