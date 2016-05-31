using UnityEngine;
using System.Collections;

public class FlyBehavior : MonoBehaviour {

	public SpriteRenderer flySpriteRenderer;

	// Use this for initialization
	void Start () {
		flySpriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void OnTriggerEnter2D(Collider2D objectCollision) {

		if (objectCollision.gameObject.tag == "Player") {
			pointsManager.flies++;
			Destroy (gameObject);
		}
	}
}
