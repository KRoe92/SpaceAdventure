using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader_Behaviour : MonoBehaviour {

	public float fadeSpeed;
	bool Increase;
	bool Decrease;

	float t;


	// Use this for initialization
	void Start () {
		fadeSpeed = 0.5f;
		fadeIn ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Increase) {
			Color fontColor = gameObject.GetComponent<Image> ().color;
			fontColor.a = Mathf.Lerp (0, 1, t);
			if (fontColor.a > 0.95f){
				Increase = false;
				t = 0;
			}
			gameObject.GetComponent<Image> ().color = fontColor;
			t += Time.deltaTime * fadeSpeed;
		}

		if (Decrease) {
			Color fontColor = gameObject.GetComponent<Image> ().color;
			fontColor.a = Mathf.Lerp (1, 0, t);
			if (fontColor.a < 0.05f) {
				Decrease = false;
				t = 0;
			}
			gameObject.GetComponent<Image> ().color = fontColor;
			t += Time.deltaTime * fadeSpeed;
		}
		
	}

	public void fadeIn()
	{
		Decrease = true;
		gameObject.GetComponent<Image> ().color = new Color (0,0,0,1);
	}

	public void fadeOut()
	{
		Increase = true;
		gameObject.GetComponent<Image> ().color = new Color (0,0,0,0);
	}
}
