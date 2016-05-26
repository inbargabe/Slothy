using UnityEngine;
using System.Collections;

public class RotateRightBranch : MonoBehaviour {

	private float baseAngle = 0.0f;
	private float ang;
	public GameObject branch;

	public TouchController m_touchController;

	void Update() {
		if (m_touchController.touchedBranch) {
			OnTouchMoved ();
		}
	}

	public void OnTouchMoved(){

		int nbTouches = Input.touchCount;

		if (nbTouches == 1) {

			Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
			Vector3 touch = Input.GetTouch (0).position;
			pos.x = - touch.x + pos.x;
			pos.y = - touch.y + pos.y;
			ang = Mathf.Atan2 (pos.y, pos.x) * Mathf.Rad2Deg - baseAngle;

			if (ang < 0)
				ang = 0f;
			else if (ang > 27f)
				ang = 27f;

			m_touchController.objToRotate.transform.rotation = Quaternion.AngleAxis (ang, Vector3.forward);
		}
	}

}
