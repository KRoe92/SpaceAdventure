using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Manager : MonoBehaviour {

	public GameObject ship;

	public GameObject gun1;
	public GameObject gun2;
	public GameObject gun3;

	public GameObject shield;

	public GameObject disp1;
	public GameObject disp2;

	public GameObject price1;
	public GameObject price2;

	public GameObject equip1;
	public GameObject equip2;

	public GameObject locked1;


	// Use this for initialization
	void Start () {
		
		if (Game_Info.PlasmaUnlocked) {

			disp2.SetActive (true);
			price2.SetActive (true);
			locked1.SetActive (false);

		}

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void upgradeGun(int price)
	{
		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Ship_Behaviour> ().getCash () >= price) {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Ship_Behaviour> ().addCash (-price);
			gun1.SetActive (false);
			gun2.SetActive (true);
			gun3.SetActive (true);

			disp1.SetActive (false);
			price1.SetActive (false);
			equip1.SetActive (true);
		}
	}

	public void upgradeShield(int price)
	{
		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Ship_Behaviour> ().getCash () >= price) {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Ship_Behaviour> ().addCash (-price);
			shield.SetActive (true);

			disp2.SetActive (false);
			price2.SetActive (false);
			equip2.SetActive (true);

			ship.GetComponent<FixedJoint2D> ().connectedBody = shield.GetComponent<Rigidbody2D>();
		}
	}
}
