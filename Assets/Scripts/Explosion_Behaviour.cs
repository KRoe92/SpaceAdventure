using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Behaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int val = Random.Range (1, 3);
		if (val == 1)
			GetComponent<SpriteRenderer> ().sortingLayerName = "thirdLayer";
		else
			GetComponent<SpriteRenderer> ().sortingLayerName = "forthLayer";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
