using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bits_behaviour : MonoBehaviour {

	//Private
	private int Degrees = 10;
	private float speed;

	//Public
	public GameObject point;
		
	void Start () {
		speed = Random.Range (160, 320);
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Mathf.Cos (Degrees * Mathf.Deg2Rad) * speed, Mathf.Sin (Degrees * Mathf.Deg2Rad) * speed));
	}

	public void setRandomScale(int min, int max)
	{
		float scale = (Random.Range (min, max)) / 40f;
		transform.localScale = new Vector3(scale, scale, 1);
	}

	public void setDirection(int degrees)
	{
		Degrees = degrees;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player"){
			coll.GetComponent<Ship_Behaviour> ().addCash (1);
			Destroy (gameObject);
		}
		if (coll.gameObject.tag == "Rig") {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Ship_Behaviour> ().addCash (1);
			Destroy (gameObject);
		}
	}

	void Update()
	{
		GameObject player;
		player = GameObject.FindGameObjectWithTag ("Player");
		GameObject[] rigs = GameObject.FindGameObjectsWithTag ("Rig");
		if(player != null)
		{
			if (Vector3.Distance (player.transform.position, transform.position) < 1) {
				Vector2 dif = new Vector2 (player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
				GetComponent<Rigidbody2D> ().AddForce (dif.normalized * 8);
			}
		}

		for (int i = 0; i < rigs.Length; i++) {

			if (Vector3.Distance (rigs[i].transform.position, transform.position) < 1.5f) {
				Vector2 dif = new Vector2 (rigs[i].transform.position.x - transform.position.x, rigs[i].transform.position.y - transform.position.y);
				GetComponent<Rigidbody2D> ().AddForce (dif.normalized * 8);
			}
		}

		if (transform.position.y < -5.5f)
			Destroy (gameObject);
	}
}
