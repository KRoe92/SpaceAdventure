using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behaviour : MonoBehaviour {

	//Private
	private float Speed;
	private int Direction;
	private float lifeSpan;

	//Public
	public bool enemy;

	// Use this for initialization
	void Start () {

		float x = Mathf.Cos (Direction * Mathf.Deg2Rad);
		float y = Mathf.Sin (Direction * Mathf.Deg2Rad);
		GetComponent<Rigidbody2D>().AddForce(new Vector2(x * Speed, y * Speed));
		if(enemy)
		{
			GetComponent<SpriteRenderer>().color = new Color(111f/255f, 203f/255f, 48f/255f);
			transform.eulerAngles = new Vector3 (0, 0, 180);
		}

	}

	public void setSpeed(float speed)
	{
		Speed = speed;
	}

	public void setDirection(int direction)
	{
		Direction = direction;
	}
	
	// Update is called once per frame
	void Update () {
		lifeSpan += Time.deltaTime;
		if (lifeSpan > (7f / (100 * Speed)))
			Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D coll) {

		if (enemy) {
			if (coll.gameObject.tag == "Plasma") {
				Destroy (gameObject);
			}
		} 
		else {

			if (coll.gameObject.tag == "Asteroid" || coll.gameObject.tag == "Enemy") {
				coll.gameObject.GetComponent<Asteroid_Behaviour> ().reduceHealth (false);
				Destroy (gameObject);
			}

			if (coll.gameObject.tag == "Boundaries")
				Destroy (gameObject);
		}
	}
}
