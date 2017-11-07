using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant_Behaviour : MonoBehaviour {

	public GameObject success;
	public GameObject failed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void buyPlasmaRig()
	{
		if (Game_Info.Money >= 1000) {
			Game_Info.Money -= 1000;
			Game_Info.PlasmaUnlocked = true;
			success.SetActive (true);
		}
		else
			failed.SetActive (true);
	}
}
