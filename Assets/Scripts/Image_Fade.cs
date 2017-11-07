using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image_Fade : MonoBehaviour {

	private float startingOpacity;
	private float t = 0.0f;
	private Vector3 statingPos;

	// Use this for initialization
	void Start () {

		startingOpacity = gameObject.GetComponent<SpriteRenderer> ().color.a;
		statingPos = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		Color fontColor = gameObject.GetComponent<SpriteRenderer> ().color;
		fontColor.a = Mathf.Lerp(startingOpacity, 0, t);
		if (fontColor.a < 0.05f)
			Destroy (gameObject);
		gameObject.GetComponent<SpriteRenderer> ().color = fontColor;

		transform.position = statingPos + new Vector3(0, t * 0.8f ,0);
		float scale = Random.Range (0.01f, 0.05f);
		transform.localScale += new Vector3 (t * scale, t * scale ,0);
		t += Time.deltaTime;
		
	}
}
