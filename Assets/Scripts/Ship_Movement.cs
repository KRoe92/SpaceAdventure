using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship_Movement : MonoBehaviour {

	public int speed;

	//Paddle Control: if not using touch controls A moves left, D moves right, M shoots ball
	void Update () {

		if(Input.GetKey(KeyCode.A))
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2(-0.5f,0) * speed);
		if(Input.GetKey(KeyCode.D))
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2(0.5f,0) * speed);
		if(Input.GetKey(KeyCode.W))
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2(0,0.5f) * speed);
		if(Input.GetKey(KeyCode.S))
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2(0,-0.5f) * speed);

		if (Input.touchCount == 1) {
			float relativeTouchX = (Input.touches [0].position.x/Screen.width - 0.5f) * 6;
			float relativeTouchY = (Input.touches [0].position.y/Screen.height - 0.5f) * 10;
			float diffX = relativeTouchX - transform.position.x;
			float diffY = relativeTouchY - transform.position.y;
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2(speed * diffX ,speed * diffY));

		}
	}
}

