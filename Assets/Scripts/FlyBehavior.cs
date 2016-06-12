using UnityEngine;
using System.Collections;

public class FlyBehavior : MonoBehaviour {

	public SpriteRenderer flySpriteRenderer;
	public static bool playerTouchedFly;

	// Use this for initialization
	void Start () {
		flySpriteRenderer = GetComponent<SpriteRenderer> ();
		playerTouchedFly = false;
	}

	void OnTriggerEnter2D(Collider2D objectCollision) {
		if (objectCollision.gameObject.tag == "Player") {
			pointsManager.flies++;
			Destroy (gameObject);
			playerTouchedFly = true;
		}
	}
}
