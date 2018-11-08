using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoSide2Side : MonoBehaviour {
	private Vector3 EndPos;
	[SerializeField] protected float speed;
	private float step;
	[SerializeField] protected GameObject Title;

	void Awake(){
		step = speed * Time.deltaTime;
		StartCoroutine ("LogoMovement");
	}

	private Vector3 changePosition(Vector3 V3){
		Vector3 temp = V3;
		temp.y -= 0.3f;
		Debug.Log("CHNAGING");
		return temp;
	}

	IEnumerator LogoMovement(){
		for(int i=0; i<3; i++) {
			Debug.Log ("awa");
			EndPos = gameObject.transform.position;
			EndPos.x += 3.7f;
			StartCoroutine ("MovingToASide");
			yield return new WaitForSeconds(7.5f);
			StopCoroutine ("MovingToASide");
			transform.position = changePosition (transform.position);
			EndPos = gameObject.transform.position;
			EndPos.x -= 3.7f;
			StartCoroutine ("MovingToASide");
			yield return new WaitForSeconds(7.5f);
			StopCoroutine ("MovingToASide");

			transform.position = changePosition (transform.position);
		}

		Title.SetActive (true);
		Destroy(gameObject);
	}

	IEnumerator MovingToASide(){
		
		while (transform.position != EndPos) {
			transform.position = Vector3.MoveTowards (transform.position, EndPos, step);
			yield return new WaitForEndOfFrame ();

		}
	}
}