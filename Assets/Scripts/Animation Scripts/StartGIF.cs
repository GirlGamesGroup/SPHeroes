using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGIF : MonoBehaviour {

	[SerializeField] protected Sprite[] frameCollection;
	[SerializeField] protected int fps;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int index = (Mathf.RoundToInt((Time.time * fps) % frameCollection.Length))-1;
		if (index != -1) {
			this.GetComponent<SpriteRenderer> ().sprite = frameCollection [index];
		}

	}
}
