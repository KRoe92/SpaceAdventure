using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mystery_Behaviour : MonoBehaviour {

	public GameObject success;
	public GameObject fail;
	public GameObject close;
	public GameObject end;

	// Use this for initialization
	void Start () {

		success.SetActive (false);
		fail.SetActive (false);
		close.SetActive (false);
		end.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void enterMystery()
	{
		if (Game_Info.EngineUnlocked) {
			success.SetActive (true);
			end.SetActive (true);
		}
		else {
			fail.SetActive (true);
			close.SetActive (true);
		}
	}

}
