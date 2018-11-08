using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScript : MonoBehaviour {
	[SerializeField] protected Sprite window1;
	[SerializeField] protected Sprite window2;

	[SerializeField] protected SpriteRenderer[] spriteRenderers;

	void Awake(){
		ActivateWindows ();
	}

	public void ChangeWindow(int position){
		spriteRenderers [position].sprite = window2;
	}

	void OnEnable(){
		ActivateWindows ();
	}

	private void ActivateWindows(){
		foreach (SpriteRenderer SR in spriteRenderers)
		{
			SR.sprite = window1;
		}
	}
}
