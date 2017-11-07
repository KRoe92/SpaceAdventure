using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ship_Spawner : MonoBehaviour {

	//Public
	public GameObject[] Splines;

	//Private
	private int currentSpline = 0;
	private bool deploying;

	// Use this for initialization
	void Start () {

		StartCoroutine ("deployFirst");
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Splines [currentSpline].transform.childCount == 0 && !deploying) {
			StartCoroutine ("deployNew");
		}
		
	}

	IEnumerator deployFirst()
	{
		
		yield return new WaitForSeconds (3f);
		Splines [0].SetActive (true);

	}

	IEnumerator deployNew()
	{
		deploying = true;
		yield return new WaitForSeconds (8f);
		Splines [currentSpline].SetActive (false);
		if (currentSpline + 1 != Splines.Length) {
			currentSpline++;
			Splines [currentSpline].SetActive (true);
		}
		else {
			Game_Info.ShipAttackGone = true;
		}
		deploying = false;
	}
}