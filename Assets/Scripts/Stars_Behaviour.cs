using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars_Behaviour : MonoBehaviour {

	private Transform one;
	private Transform two;
	private bool paused;

	// Use this for initialization
	void Start () {

		one = transform.GetChild (0);
		two = transform.GetChild (1);
	}
	
	// Update is called once per frame
	void Update () {
		if (!paused) {
			one.position -= new Vector3 (0, Time.deltaTime * 0.75f, 0);
			two.position -= new Vector3 (0, Time.deltaTime * 0.75f, 0);
			if (one.localPosition.y <= -19.5f) {
				one.localPosition = new Vector3 (0, 19.5f, 0);
			}
			if (two.localPosition.y <= -19.5f)
				two.localPosition = new Vector3 (0, 19.5f, 0);
		}
		
	}

	public void toggleStars()
	{
		if (paused)
			paused = false;
		else
			paused = true;
	}
}
