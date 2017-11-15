using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroPage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator loadMap()
	{
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene ("Map");
	}

	public void startDemo()
	{
		StartCoroutine ("loadMap");
	}
}
