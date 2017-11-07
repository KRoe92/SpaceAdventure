using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void_Behaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Asteroid") {
			coll.gameObject.GetComponent<Asteroid_Behaviour> ().reduceHealth (true);
			StartCoroutine (killAnimationAtEnd ());
		}
	}

	private IEnumerator killAnimationAtEnd()
	{
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
	}
}
