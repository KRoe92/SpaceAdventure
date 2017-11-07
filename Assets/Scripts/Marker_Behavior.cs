using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marker_Behavior : MonoBehaviour {

	public GameObject startButton;
	public GameObject location;
	public GameObject sign;
	public string name;
	public Vector3 pos;

	// Use this for initialization
	void Start () {

	//	pos = transform.position;		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		startButton.SetActive (true);
		location.GetComponent<Text> ().text = name;
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		startButton.SetActive (false);
	}

	public void setComplete()
	{
		sign.GetComponent<Text> ().text = "✓";
	}
}
