using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	public Touch touch;
	public GameObject obj;

	public GameObject objToRotate;

	public bool touchedBranch;
	public bool touchedPlayer;
	public int firstArrow;

	public SlothBehavior m_slothBehavior;
	public bool stopMovingWithBranch;

	void Start() {
		touchedPlayer = false;
	}

	void FixedUpdate() {
		int nbTouches = Input.touchCount;

		if (nbTouches == 1) {

			// get the first touch on screen
			touch = Input.GetTouch (0);
			TouchPhase phase = touch.phase;
			Ray screenRay = Camera.main.ScreenPointToRay (touch.position);

			// get where we hit in the screen.
			RaycastHit2D hit = Physics2D.Raycast (screenRay.origin, screenRay.direction);

			if (phase == TouchPhase.Began) {

				if (hit) {
					obj = hit.collider.gameObject;
					print ("User tapped on game object " + obj.tag);

					if (obj.tag == "Branch") {
						firstArrow++;
						touchedBranch = true;
						objToRotate = obj;

						// If sloth is on a moving branch and is being touched again.
					} else if (obj.name == "sloth" && m_slothBehavior.touchedMovingBranch) {
						touchedPlayer = true;
						stopMovingWithBranch = true;
					} else if (obj.name == "sloth") {
						touchedPlayer = true;
					}
				}
			} if (phase == TouchPhase.Ended) {
				if (touchedBranch) {
					touchedBranch = false;
				} else if (touchedPlayer) {
					touchedPlayer = false;
				}
			}
		}
	}
}
