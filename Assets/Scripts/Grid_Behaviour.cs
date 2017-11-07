using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Behaviour : MonoBehaviour {

	private bool increase;

	private GameObject grid1;
	private GameObject grid2;

	// Use this for initialization
	void Start () {

		increase = false;
		grid1 = transform.GetChild (0).gameObject;
		grid2 = transform.GetChild (1).gameObject;
		
	}
	
	// Update is called once per frame
	void Update () {

		Color c = grid1.GetComponent<SpriteRenderer> ().color;
		if (increase) {
			grid1.GetComponent<SpriteRenderer> ().color = new Color (c.r, c.g, c.b, c.a + Time.deltaTime/8);
			grid2.GetComponent<SpriteRenderer> ().color = new Color (c.r, c.g, c.b, c.a + Time.deltaTime/8);
		}

		else {
			grid1.GetComponent<SpriteRenderer> ().color = new Color (c.r, c.g, c.b, c.a - Time.deltaTime/8);
			grid2.GetComponent<SpriteRenderer> ().color = new Color (c.r, c.g, c.b, c.a + Time.deltaTime/8);
		}

		if (c.a * 255 > 38)
			increase = false;
		if (c.a * 255 < 1)
			increase = true;
	}
}
