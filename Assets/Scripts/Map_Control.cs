using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Map_Control : MonoBehaviour {

	//Public
	public Transform target;
	public GameObject location;
	public GameObject money;
	public GameObject[] mapMarkers;

	//Private
	private float speed = 0.5f;
	private Vector2 pos;
	private bool turning;

	// Use this for initialization
	void Start () {
		//pos = new Vector2(target.position.x, target.position.y);

		Marker_Behavior marker = mapMarkers [Game_Info.MarkerNum].GetComponent<Marker_Behavior> ();
		pos = new Vector2(marker.pos.x, marker.pos.y);
		transform.position = marker.pos;
		setName (marker.name);
		setMoney ();
		if (Game_Info.AsteroidGone) {
			mapMarkers[2].SetActive (false);
			marker.setComplete ();
		}

		if (Game_Info.ShipAttackGone) {
			mapMarkers[3].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (turning) {
			var dir = new Vector3 (pos.x, pos.y, 0) - transform.position;
			var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Slerp (transform.localRotation, Quaternion.AngleAxis (angle, Vector3.forward), Time.deltaTime);
		
			if (Mathf.Abs (transform.localRotation.eulerAngles.z - Quaternion.AngleAxis (angle, Vector3.forward).eulerAngles.z) < 5)
			{
				if(!gameObject.GetComponent<AudioSource> ().isPlaying)
					gameObject.GetComponent<AudioSource> ().Play ();
			}

			if (Mathf.Abs (transform.localRotation.eulerAngles.z - Quaternion.AngleAxis (angle, Vector3.forward).eulerAngles.z) < 3) {
				turning = false;
			}
		} 
		else {
			float step = speed * Time.deltaTime;
			Vector2 vec = Vector2.Lerp (new Vector2 (transform.position.x, transform.position.y), pos, step);
			transform.position = new Vector3 (vec.x, vec.y, 0);
		}
		
	}

	public void setTarget(Transform tar)
	{
		pos = new Vector2(tar.position.x, tar.position.y);
		turning = true;
	}

	public void setName(string name)
	{
		location.GetComponent<Text> ().text = name;
	}

	public void setMoney()
	{
		money.GetComponent<Text> ().text = Game_Info.Money + "";
	}

	public void setLevelNum(int num)
	{
		Game_Info.LevelNum = num;
	}

	public void loadLevel(string lev)
	{
		
		StartCoroutine ("load");
	}

	public void endGame()
	{
		StartCoroutine ("closeMap");
	}

	IEnumerator load()
	{
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene ("InGame");
	}

	IEnumerator closeMap()
	{
		yield return new WaitForSeconds (2.5f);
		Application.Quit ();
	}
		
}
