using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SlothBehavior : MonoBehaviour {

	public TouchController m_touchController;

	public GameObject sloth;
	public GameObject movingBranch;
	public GameObject hugeMovingBranch;
	public Collider2D collisionObject;
	public GameObject deathScreen;

	public Rigidbody2D slothRigidBody;

	public bool touchedMovingBranch;

	void Start() {
		slothRigidBody = sloth.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

		// If user touched the sloth - drop the sloth from the collider it's on 
		if (m_touchController.touchedPlayer && collisionObject != null) {
			slothRigidBody.gravityScale = 1;
			slothRigidBody.mass = 0.7f;
			print ("Collider is " + collisionObject.tag);
			collisionObject.isTrigger = true;
			m_touchController.touchedPlayer = false;
		}

			
		// Sloth landed on moving branch and starts moving with it 
		if (collisionObject != null && collisionObject.tag == "MovingBranch") {
			touchedMovingBranch = true;
			sloth.transform.parent = movingBranch.transform;
		}

		// make the sloth stop moving with the moving branch
		if (collisionObject != null && collisionObject.tag == "Branch" && touchedMovingBranch) {
			touchedMovingBranch = false;
			sloth.transform.parent = null;
		}

		// Sloth landed on huge branch
		if (collisionObject != null && collisionObject.tag == "HugeMovingBranch") {
			sloth.transform.parent = hugeMovingBranch.transform;
		}

		if (sloth.transform.position.y < -7 || sloth.transform.position.y > 10
			|| sloth.transform.position.x < -14 || sloth.transform.position.x > 13) {
			print ("slothy died.");
			deathScreen.SetActive(true);
			Time.timeScale = 0;
		}
	}



	void OnCollisionEnter2D(Collision2D objectCollision) {
		collisionObject = objectCollision.gameObject.GetComponent<Collider2D>();
		print("Sloth collided with " + collisionObject.tag);

		string objectTag = objectCollision.gameObject.tag;

		// User fails.
		if (objectTag == "BranchWithThorns" || objectTag == "Enemy") {
			deathScreen.SetActive(true);
			Time.timeScale = 0;
		}


		if (objectTag == "Fly") {
			pointsManager.flies++;
			Destroy (objectCollision.gameObject);
		}

		if (objectTag == "Fruit") {
			sloth.transform.parent = null;
			//slothRigidBody.isKinematic = true;
		}
	}
}
