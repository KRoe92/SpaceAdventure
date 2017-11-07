using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Attack : MonoBehaviour {

	public GameObject boom;
	public float time;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("explosions", 1, time);
	}
	
	// Update is called once per frame
	void explosions () {

		GameObject inst = Instantiate (boom, transform.position, Quaternion.identity);
		inst.transform.localScale = new Vector3 (0.02f, 0.02f, 1);
		inst.transform.position += new Vector3 (Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f) ,0);
		inst.gameObject.GetComponent<AudioSource> ().volume = 0.01f;
		
	}
}
