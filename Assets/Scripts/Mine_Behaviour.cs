using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine_Behaviour : MonoBehaviour {

	public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Asteroid") {
			Instantiate (explosion, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
