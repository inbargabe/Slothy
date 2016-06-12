using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FruitBehavior : MonoBehaviour {

	public GameObject EndOfStage;

	public GameObject fruit;
	public SpriteRenderer fruitSpriteRenderer;
	public CircleCollider2D fruitCollider;

	public GameObject branch1;
	public BoxCollider2D branch1Collider;

	public static bool finishedLevel;

	void Start() {
		branch1Collider = branch1.GetComponent<BoxCollider2D> ();
		fruitSpriteRenderer = fruit.GetComponent<SpriteRenderer> ();
		fruitCollider = fruit.GetComponent<CircleCollider2D> ();
		finishedLevel = false;
	}

	void OnCollisionEnter2D(Collision2D objectCollision) {

		if (objectCollision.gameObject.tag == "Player") {
			fruitCollider.isTrigger = true;
			fruitSpriteRenderer.enabled = false;


			EndOfStage.SetActive (true);

			print ("im here at points manager");

			// for canvas manager on main menu.
			string level = "MaxFliesOfLevel" + SceneManager.GetActiveScene ().buildIndex;

			//TODO: display how many stars collected in level menu.
			if (pointsManager.flies > PlayerPrefs.GetInt (level)) {
				PlayerPrefs.SetInt (level, pointsManager.flies);
			} 

			// for canvas manager on main menu. 
			int levelNumber = SceneManager.GetActiveScene().buildIndex;
			if (levelNumber > PlayerPrefs.GetInt("levelNumber")) {
				PlayerPrefs.SetInt("levelNumber", levelNumber);
			}

			finishedLevel = true;
			branch1Collider.isTrigger = false;
		}
	}
}
