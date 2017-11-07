using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Keeper : MonoBehaviour {

	private float timeFloat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Text> ().text = timeFloat.ToString ("#.00");
		timeFloat += Time.deltaTime;
		
	}
		
}
