using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant_Behaviour : MonoBehaviour {

	public GameObject success;
	public GameObject failed;
	public GameObject yes;
	public GameObject no;
	public GameObject close;
	public GameObject soldOut;

	// Use this for initialization
	void Start () {
		
	}

	void Awake()
	{
		if (Game_Info.PlasmaUnlocked) {
			yes.SetActive (false);
			no.SetActive (false);
			gameObject.SetActive (false);
		}
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
