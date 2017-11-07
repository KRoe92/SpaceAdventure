using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Behaviour : MonoBehaviour {

	public GameObject powerPrefab;
	public int price;
	GameObject powerInstance;
	int ready;


	public void deploy()
	{
		if(GameObject.FindGameObjectWithTag("Player").GetComponent<Ship_Behaviour>().getCash() >= price)
		{
			if (ready == 0) {
				powerInstance = Instantiate (powerPrefab, new Vector3 (1000, 1000, 0), Quaternion.identity);
				ready = 1;
			}
		}
	}

	void Start () {
		ready = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (ready == 2) {
			if (Input.touchCount == 1) {
				float relativeTouchX = (Input.touches [0].position.x / Screen.width - 0.5f) * 6;
				float relativeTouchY = (Input.touches [0].position.y / Screen.height - 0.5f) * 10;
			
				for (int i = 0; i < 8; i++) {
					float posX = -2.626f + (i * 0.755f);
					if(relativeTouchX > posX - (0.755f/2) && relativeTouchX < posX + (0.755f/2))
						relativeTouchX = posX;
				}

				for (int i = 0; i < 10; i++) {
					float posY = -3.025f + (i * 0.755f);
					if(relativeTouchY > posY - (0.755f/2) && relativeTouchY < posY + (0.755f/2))
						relativeTouchY = posY;
				}

				powerInstance.transform.position = new Vector3 (relativeTouchX, relativeTouchY, 0);
				ready = 0;
			}

			if (Input.GetMouseButtonDown (0)) {
				Vector3 p = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				float relativeTouchX = p.x;
				float relativeTouchY = p.y;

				if (p.y > -3.25f && p.y < 4f) {
					for (int i = 0; i < 8; i++) {
						float posX = -2.626f + (i * 0.755f);
						if (relativeTouchX > posX - (0.755f / 2) && relativeTouchX < posX + (0.755f / 2))
							relativeTouchX = posX;
					}

					for (int i = 0; i < 10; i++) {
						float posY = -3.025f + (i * 0.755f);
						if (relativeTouchY > posY - (0.755f / 2) && relativeTouchY < posY + (0.755f / 2))
							relativeTouchY = posY;
					}

					powerInstance.transform.position = new Vector3 (relativeTouchX, relativeTouchY, 0);
					ready = 0;
					GameObject.FindGameObjectWithTag ("Player").GetComponent<Ship_Behaviour> ().addCash (-price);
					GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Game_Behaviour> ().pauseGame ();
				}
			}
		}

		if (ready == 1) {

			if(Input.GetMouseButtonUp(0))
			{
				ready = 2;
			}
		}
	}
}
