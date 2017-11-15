using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Behaviour : MonoBehaviour {

	public GameObject overlay;
	public GameObject enemySpawner;
	public GameObject enemyShipSpawner;
	public GameObject stars;
	public GameObject grid;
	public GameObject missionComplete;
	public GameObject reward;
	public GameObject reward2;
	public bool gameOver;
	public bool GameSuccess;
	float alpha = 0;
	bool paused;

	public GameObject retry;
	public GameObject returnToMap;
	float timeKeeping;
	public float timeLimit = 140;

	// Use this for initialization
	void Start () {

		if (Game_Info.LevelNum == 2) {
			enemyShipSpawner.SetActive (true);
			enemySpawner.GetComponent<Asteroid_Spawner> ().asteroidPeriod = 1.3f;
			enemySpawner.GetComponent<Asteroid_Spawner> ().limit = 25;
			enemySpawner.GetComponent<Asteroid_Spawner> ().numOfBits = 5;
			timeLimit = 80;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver) {
			Color c = overlay.GetComponent<Image> ().color;
			overlay.GetComponent<Image> ().color = new Color (c.r, c.g, c.b, alpha);
			alpha += Time.deltaTime * 0.2f;

			if (alpha >= 250f/255) {
				retry.SetActive (true);
				returnToMap.SetActive (true);
			}
		}

		if(!paused)
			timeKeeping += Time.deltaTime;
		if (timeKeeping > timeLimit) {
			GameObject[] asteroids = GameObject.FindGameObjectsWithTag ("Asteroid");

			if(Game_Info.LevelNum == 2)
			{
				if(Game_Info.ShipAttackGone)
					GameSuccess = true;
			}

			if (asteroids.Length == 0) {
				GameSuccess = true;
			}
			else {
				timeLimit += 5;
			}
		}

		if (GameSuccess) {
			Color c = missionComplete.GetComponent<Text> ().color;
			missionComplete.GetComponent<Text> ().color = new Color (c.r, c.g, c.b, c.a + Time.deltaTime);
			if(Game_Info.LevelNum == 1)
				reward.SetActive (true);
			else
				reward2.SetActive (true);
		}

	}

	public void hardPause(bool val)
	{
		if (val)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}

	public void pauseGame()
	{
		if(!paused)
		{
			GameObject[] asteroids = GameObject.FindGameObjectsWithTag ("Asteroid");
			for (int i = 0; i < asteroids.Length; i++) {
				asteroids [i].GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}

			GameObject[] bits = GameObject.FindGameObjectsWithTag ("Bits");
			for (int i = 0; i < bits.Length; i++) {
				bits [i].GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}

			GameObject[] bullets = GameObject.FindGameObjectsWithTag ("Bullet");
			for (int i = 0; i < bullets.Length; i++) {
				bullets [i].GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}

			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;

			GameObject[] guns = GameObject.FindGameObjectsWithTag ("Gun");
			/*for (int i = 0; i < guns.Length; i++) {
				guns [i].GetComponent<Gun_Control> ().cancelShoot ();
			}*/

			enemySpawner.GetComponent<Asteroid_Spawner> ().pauseSpawner ();
			stars.GetComponent<Stars_Behaviour> ().toggleStars ();
			grid.SetActive (true);
			paused = true;
		}

		else
		{
			GameObject[] asteroids = GameObject.FindGameObjectsWithTag ("Asteroid");
			for (int i = 0; i < asteroids.Length; i++) {
				asteroids [i].GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			}

			GameObject[] bits = GameObject.FindGameObjectsWithTag ("Bits");
			for (int i = 0; i < bits.Length; i++) {
				bits[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
			}

			GameObject[] bullets = GameObject.FindGameObjectsWithTag ("Bullet");
			for (int i = 0; i < bullets.Length; i++) {
				bullets[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
			}

			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

			GameObject[] guns = GameObject.FindGameObjectsWithTag ("Gun");
			/*for (int i = 0; i < guns.Length; i++) {
				guns [i].GetComponent<Gun_Control> ().startShoot ();
			}*/

			enemySpawner.GetComponent<Asteroid_Spawner> ().unpauseSpawner ();
			stars.GetComponent<Stars_Behaviour> ().toggleStars ();
			grid.SetActive (false);
			paused = false;
		}
	}

	public bool getPausedState()
	{
		if (paused)
			return true;
		else
			return false;
	}

	public void setLayOver(float al)
	{
		Color c = overlay.GetComponent<Image> ().color;
		overlay.GetComponent<Image> ().color = new Color (c.r, c.g, c.b, al);
	}

	public void reloadLevel()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	IEnumerator loadMap()
	{
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene ("Map");
	}

	public void gameSuccess()
	{
		Game_Info.AsteroidGone = true;
		Game_Info.MarkerNum = 2;
		Game_Info.Money = 1000;
		StartCoroutine ("loadMap");
	}

	public void gameSuccess2()
	{
		Game_Info.ShipAttackGone = true;
		Game_Info.EngineUnlocked = true;
		Game_Info.MarkerNum = 3;
		Game_Info.Money = 0;
		StartCoroutine ("loadMap");
	}

}
