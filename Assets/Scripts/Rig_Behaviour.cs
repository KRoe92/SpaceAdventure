using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rig_Behaviour : MonoBehaviour {

	public GameObject bitPrefab;
	public int numOfBits;
	public Color Colr;
	public int Cash;

	void Update()
	{
		transform.Rotate (new Vector3( 0, 0, 40 * Time.deltaTime));
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Asteroid") {
			coll.gameObject.GetComponent<Asteroid_Behaviour> ().reduceHealth (false);
			for (int i = 0; i < 6; i++) {
				GameObject bit = Instantiate (bitPrefab, transform.position, Quaternion.identity);
				bit.GetComponent<Death_Behaviour> ().setDirection ((360 / numOfBits) * i);
				bit.GetComponent<Death_Behaviour> ().setColor (Colr);
			}
			Destroy (gameObject);
		}
	}

	public void addCash()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<Ship_Behaviour> ().addCash (Cash);
	}
}
