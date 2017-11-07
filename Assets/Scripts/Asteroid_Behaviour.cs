using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Behaviour : MonoBehaviour {

	//Private
	private float Speed;
	private float Health;
	private float drag;

	//Public
	public GameObject bitPrefab;
	public GameObject exPrefab;
	public float num = 5f;
	public Color bitsColor = Color.white;

	// Use this for initialization
	void Start () {

		GetComponent<Rigidbody2D>().drag = 15 * transform.localScale.x;
		drag = GetComponent<Rigidbody2D> ().drag;
	}

	public void setSpeed(float speed)
	{
		Speed = speed;
	}

	public void setHealth(float health)
	{
		Health = health;
	}


	public void reduceHealth(bool Instant)
	{
		Health-=2;
		if (Instant)
			Health = 0;
		float numOfBits = num * transform.localScale.x;
		int start = Random.Range (0, 30);
		if (Health < 1) {
			for (int i = 0; i < numOfBits; i++) {
				GameObject bit = Instantiate (bitPrefab, transform.position, Quaternion.identity);
				bit.GetComponent<Bits_behaviour> ().setDirection (((360 / (int)numOfBits) * i) + start);
				bit.GetComponent<Bits_behaviour> ().setRandomScale (2, 5);
				bit.GetComponent<SpriteRenderer> ().color = bitsColor;
			}
			GameObject ex = Instantiate (exPrefab, transform.position, Quaternion.identity);
			ex.transform.localScale = ex.transform.localScale * transform.localScale.x;
			Destroy (gameObject);
		} 
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y < -5.5f)
			Destroy (gameObject);
	}
}
