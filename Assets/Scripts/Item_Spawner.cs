using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Spawner : MonoBehaviour {

	public GameObject SentryPrefab;
	public GameObject RigPrefab;
	private int gunLevel = 1;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.M))
			Instantiate(SentryPrefab, transform.position, Quaternion.identity);
		if(Input.GetKeyDown(KeyCode.N))
			Instantiate(RigPrefab, transform.position, Quaternion.identity);
		if (Input.GetKeyDown (KeyCode.B)) {
			if (gunLevel == 1) {
				transform.GetChild (0).gameObject.SetActive (false);
				transform.GetChild (1).gameObject.SetActive (true);
				transform.GetChild (2).gameObject.SetActive (true);
			}
			else {
				transform.GetChild (0).gameObject.SetActive (true);
			}
			gunLevel++;
		}
	}
}
