using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship_Behaviour : MonoBehaviour {

	//Public
	public GameObject bitPrefab;
	public int numOfBits;
	public Color Colr;
	public GameObject cashText;

	//Private
	private int Cash;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Asteroid") {
			coll.gameObject.GetComponent<Asteroid_Behaviour> ().reduceHealth (false);
			for (int i = 0; i < numOfBits; i++) {
				GameObject bit = Instantiate (bitPrefab, transform.position, Quaternion.identity);
				bit.GetComponent<Death_Behaviour> ().setDirection ((360 / numOfBits) * i);
				bit.GetComponent<Death_Behaviour> ().setColor (Colr);
			}
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Game_Behaviour> ().gameOver = true;
			Destroy (gameObject);
		}
	}

	public void addCash(int amount)
	{
		Cash += amount;
		cashText.GetComponent<Text> ().text = "" + Cash;
	}

	public int getCash()
	{
		return Cash;
	}
}
