using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Spawner : MonoBehaviour {

	//Private
	private float asteroidSpeed;
	private bool paused;
	private int asteroidNum;

	//Public
	public float asteroidPeriod;
	public GameObject asteroidPrefab;
	public int numOfBits = 5;

	public int limit = 80;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnAsteroid", 2, asteroidPeriod);
	}

	// Update is called once per frame
	void Update () {

		if (asteroidNum == limit) {
			asteroidNum++;

		}

	}

	void spawnAsteroid()
	{
		if (!paused && asteroidNum < limit) {
			float xPos = Random.Range (-2.7f, 2.0f);
			float scale = Random.Range (2.0f, 4.0f);
			float health = scale * 2f;
			asteroidSpeed = 1.5f - ((scale - 1.5f) / 2);
			GameObject asteroidInstance = Instantiate (asteroidPrefab, new Vector3 (xPos, 6, 0), Quaternion.identity);
			asteroidInstance.GetComponent<Asteroid_Behaviour> ().setSpeed (asteroidSpeed);
			asteroidInstance.GetComponent<Asteroid_Behaviour> ().setHealth (health);
			asteroidInstance.GetComponent<Asteroid_Behaviour> ().num = numOfBits;
			asteroidInstance.transform.localScale = new Vector3 (scale / 5, scale / 5, 1);
			asteroidNum++;
		}


		if (asteroidNum % 20 == 0) {
			asteroidPeriod /= 1.35f;
			CancelInvoke ();
			InvokeRepeating ("spawnAsteroid", 2, asteroidPeriod);
		}
	}

	public void pauseSpawner()
	{
		paused = true;
	}

	public void unpauseSpawner()
	{
		paused = false;
	}
}
