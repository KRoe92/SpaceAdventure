using UnityEngine;

public class SplineWalker : MonoBehaviour {

	public BezierSpline spline;

	public float duration;
	public int queuePos;
	public float dis;

	private float progress;
	public bool goingForward = true;

	void Start()
	{
		progress = queuePos * dis;
		Vector3 position = spline.GetPoint(0);
		transform.localPosition = position;
		var dir =  spline.GetDirection(0);
		var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle + 90, Vector3.forward);

	}

	private void Update () {
		if (goingForward && !GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game_Behaviour>().getPausedState()) {
			progress += Time.deltaTime / duration;
			if (progress > 1f) {
				progress -= 1f;
			}
		}

		Vector3 position = spline.GetPoint(progress);
		transform.localPosition = position;
		var dir =  spline.GetDirection(progress);
		var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle + 90, Vector3.forward);
	}
}