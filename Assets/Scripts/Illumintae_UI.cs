using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Illumintae_UI : MonoBehaviour {

	bool increase;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < transform.childCount; i++) {
			Transform child = transform.GetChild (i);
			Color c = child.gameObject.GetComponent<Image> ().color;
			float speed = -6;
			if (increase)
				speed *= -1;
			child.gameObject.GetComponent<Image> ().color = new Color (c.r, c.g, c.b, c.a + Time.deltaTime / speed);
		}

		Transform test = transform.GetChild (0);
		Color ctest = test.gameObject.GetComponent<Image> ().color;

		if (ctest.a * 255 > 240)
			increase = false;
		if (ctest.a * 255 < 2)
			increase = true;

	}
}
