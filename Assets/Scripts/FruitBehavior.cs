using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FruitBehavior : MonoBehaviour {

	public GameObject EndOfStage;

	public GameObject fruit;
	public SpriteRenderer fruitSpriteRenderer;
	public CircleCollider2D fruitCollider;

	public GameObject branch1;
	public BoxCollider2D branch1Collider;


	void Start() {
		branch1Collider = branch1.GetComponent<BoxCollider2D> ();
		fruitSpriteRenderer = fruit.GetComponent<SpriteRenderer> ();
		fruitCollider = fruit.GetComponent<CircleCollider2D> ();
	}

	void OnCollisionEnter2D(Collision2D objectCollision) {

		if (objectCollision.gameObject.tag == "Player") {
			fruitCollider.isTrigger = true;
			fruitSpriteRenderer.enabled = false;
			EndOfStage.SetActive (true);
			branch1Collider.isTrigger = false;
		}
	}
}
