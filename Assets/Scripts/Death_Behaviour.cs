using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Behaviour : MonoBehaviour {

	private int Degrees = 10;
	private float speed;
	private float lifeSpan;

	public void setDirection(int degrees)
	{
		Degrees = degrees;
	}

	public void setColor(Color myCol)
	{
		GetComponent<SpriteRenderer> ().color = myCol;
	}

	void Start () {
		speed = Random.Range (160, 320);
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Mathf.Cos (Degrees * Mathf.Deg2Rad) * speed, Mathf.Sin (Degrees * Mathf.Deg2Rad) * speed));
	}
	
	// Update is called once per frame
	void Update () {
		lifeSpan += Time.deltaTime;
		if (lifeSpan > 1)
			Destroy (gameObject);
	}
}
