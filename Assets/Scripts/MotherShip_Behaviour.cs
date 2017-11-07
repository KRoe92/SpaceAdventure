using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip_Behaviour : MonoBehaviour {

	public GameObject smoke;
	public GameObject explosion;
	public GameObject hud;

	private float nextSmokeTime = 0.0f;
	private float nextExplosionTime = 0.0f;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Asteroid") {
			coll.gameObject.GetComponent<Asteroid_Behaviour> ().reduceHealth (true);
			changeColor (50, 30);
		}

		if (coll.gameObject.tag == "Bullet") {
			Destroy (coll.gameObject);
			changeColor (50, 10);
		}
	}

	void changeColor(float val, float hudVal)
	{
		Color c = GetComponent<SpriteRenderer> ().color;
		Color c2 = hud.GetComponent<SpriteRenderer> ().color;
		GetComponent<SpriteRenderer> ().color = new Color (c.r, c.g - val/255, c.b - val/255);
		hud.GetComponent<SpriteRenderer> ().color = new Color (c2.r + hudVal/255, c2.g , c2.b - hudVal/255, c2.a);
	}
		
	
	// Update is called once per frame
	void Update () {
		float period = Random.Range (0.3f, 2.0f);
		if (Time.time > nextSmokeTime) {
			if (GetComponent<SpriteRenderer> ().color.g * 255.0f < 110) {
				int child = Random.Range (0, transform.childCount);
				GameObject smokeCloud = Instantiate (smoke, transform.GetChild (child).position, Quaternion.identity);
				smokeCloud.transform.localScale = new Vector3 (0.2f, 0.2f, 1);
			}
			nextSmokeTime += period;
		}

		if (Time.time > nextExplosionTime) {
			if (GetComponent<SpriteRenderer> ().color.g * 255.0f < 10) {
				int child = Random.Range (0, transform.childCount);
				float scale = Random.Range (0.2f, 0.4f);
				GameObject smokeCloud = Instantiate (explosion, transform.GetChild (child).position, Quaternion.identity);
				smokeCloud.transform.localScale = new Vector3 (scale, scale, 1);
				GameObject game = GameObject.FindGameObjectWithTag("MainCamera");
				game.GetComponent<Game_Behaviour>().gameOver = true;
			}
			nextExplosionTime += period;
		}
	}
}
