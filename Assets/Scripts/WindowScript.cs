using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScript : MonoBehaviour {
	[SerializeField] protected Sprite window1;
	[SerializeField] protected Sprite window2;

	[SerializeField] protected SpriteRenderer[] spriteRenderers;

	void Awake(){

		foreach (SpriteRenderer SR in spriteRenderers)
		{
			SR.sprite = window1;
		}
	}

	public void ChangeWindow(int position){
		spriteRenderers [position].sprite = window2;
	}


}
