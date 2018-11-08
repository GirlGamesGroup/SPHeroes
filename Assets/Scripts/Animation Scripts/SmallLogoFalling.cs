using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallLogoFalling : MonoBehaviour {
	private Vector3 EndPos;
	[SerializeField] protected float speed;
	private float step;
	[SerializeField] protected GameObject Start;

	void Awake(){
		step = speed * Time.deltaTime;

		StartCoroutine ("MovingDown");
	}

	IEnumerator MovingDown(){
//		EndPos = new Vector3 (-0.1677265f, 0.384f, -0.00476402f);
//		int i = 0;
//		while (transform.position != EndPos) {
//			transform.position = Vector3.MoveTowards (transform.position, EndPos, step);
//			yield return new WaitForEndOfFrame ();
//			i++;
//			if (i == 120) {
//				Start.SetActive (true);
//			}
//		}
		yield return new WaitForSeconds(2f);
		Start.SetActive (true);
	}
}
