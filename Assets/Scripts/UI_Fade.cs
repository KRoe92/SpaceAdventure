using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Fade : MonoBehaviour {

	private float startingOpacity;
	private float t = 0.0f;
	private Vector3 statingPos;

	//A simple class for the "points" opactity and floating affect.
	void Start () {
		
		startingOpacity = gameObject.GetComponent<Text> ().color.a;
		statingPos = transform.position;
	}


	void Update () {

		//Opacity
		Color fontColor = gameObject.GetComponent<Text> ().color;
		fontColor.a = Mathf.Lerp(startingOpacity, 0, t);
		gameObject.GetComponent<Text> ().color = fontColor;

		//Position
		transform.position = statingPos + new Vector3(0, t * 0.8f ,0);
		t += Time.deltaTime;
	}
}
