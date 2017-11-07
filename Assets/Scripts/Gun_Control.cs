using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Control : MonoBehaviour {

	//Public
	public float shootPeriod;
	public float bulletSpeed;
	public int bulletDirection;
	public bool enemy;
	public GameObject bulletPrefab;


	// Use this for initialization
	void Start () {
		repeatFire ();
	}

	void OnEnable(){
		repeatFire ();
	}

	void OnDisable(){
		CancelInvoke ();
	}

	void repeatFire()
	{
		CancelInvoke ();
		if (enemy) {
			int r = Random.Range (5, 15);
			InvokeRepeating ("shoot", r, r);
		}
		else
			InvokeRepeating ("shoot", 2, shootPeriod);
	}

	void shoot()
	{
		if (!GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game_Behaviour>().getPausedState()) {
			GameObject bulletInstance = Instantiate (bulletPrefab, transform.position, Quaternion.identity);
			bulletInstance.GetComponent<Bullet_Behaviour> ().setDirection (bulletDirection);
			bulletInstance.GetComponent<Bullet_Behaviour> ().setSpeed (bulletSpeed);
			bulletInstance.GetComponent<Bullet_Behaviour> ().enemy = enemy;
		}
	}

}
