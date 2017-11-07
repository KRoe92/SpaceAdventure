using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Portal : MonoBehaviour {

	//Public
	public BezierSpline spline;
	public GameObject portalPrefab;
	public float pos;

	//Private
	private bool destroy;
	private GameObject portal;
	private float t;
	private float t2;

	// Use this for initialization
	void Start () {

		Vector3 position = GetComponent<BezierSpline>().GetPoint(pos);
		portal = Instantiate (portalPrefab, position, Quaternion.identity);
		StartCoroutine ("deployEnemies");
		StartCoroutine ("destroySelf");
	}
	
	// Update is called once per frame
	void Update () {

		portal.transform.position = GetComponent<BezierSpline>().GetPoint(pos);
		t += 0.5f * Time.deltaTime;
		float g = Mathf.Lerp (0, 1, t);
		portal.transform.localScale = new Vector3 (g, g, 1);

		if (destroy) {
		
			t2 += 0.5f * Time.deltaTime;
			float g2 = Mathf.Lerp (0, 1, t2);
			portal.transform.localScale = new Vector3 (1 - g2, 1 - g2, 1);

		}
	}

	IEnumerator deployEnemies()
	{
		yield return new WaitForSeconds (2f);
		Transform tran = transform.GetChild (0);
		float gap = tran.gameObject.GetComponent<SplineWalker> ().duration * tran.gameObject.GetComponent<SplineWalker> ().dis;
		Transform tran2 = transform.GetChild (1);
		Transform tran3 = transform.GetChild (2);
		Transform tran4 = transform.GetChild (3);
		Transform tran5 = transform.GetChild (4);
		Transform tran6 = transform.GetChild (5);
		tran.gameObject.SetActive (true);
		yield return new WaitForSeconds (gap);
		tran2.gameObject.SetActive (true);
		yield return new WaitForSeconds (gap);
		tran3.gameObject.SetActive (true);
		yield return new WaitForSeconds (gap);
		tran4.gameObject.SetActive (true);
		yield return new WaitForSeconds (gap);
		tran5.gameObject.SetActive (true);
		yield return new WaitForSeconds (gap);
		tran6.gameObject.SetActive (true);
	}

	IEnumerator destroySelf()
	{
		yield return new WaitForSeconds (10f);
		destroy = true;
	}
}
