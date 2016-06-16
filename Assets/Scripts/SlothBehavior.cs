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
	public GameObject Snake;
	public GameObject Herpina;
	public GameObject Nest;

	// sound booleans
	public bool slothyDied;
	public bool slothyJumping;
	public bool slothyOnSlipery;
	public bool slothyOnGaizer;
	public bool slothyOnThorns;
	public bool snakeCloseToSloth;
	public bool herpinaCloseToSloth;
	public bool nestCloseToSloth;
	public bool slothyTouchFruit;

	public Animator animator;

	void Start() {
		slothyDied = false;
		slothyJumping = false;
		slothyOnSlipery = false;
		slothyOnThorns = false;
		snakeCloseToSloth = false;
		herpinaCloseToSloth = false;
		nestCloseToSloth = false;
		slothyOnGaizer = false;
		slothyTouchFruit = false;

		Snake = null;
		Herpina = null;
		Nest = null;

		slothRigidBody = sloth.GetComponent<Rigidbody2D> ();

	}

	// Update is called once per frame
	void Update () {

		// If user touched the sloth - drop the sloth from the collider it's on 
		if (m_touchController.touchedPlayer && collisionObject != null) {
			print ("Collider is " + collisionObject.tag);
			collisionObject.isTrigger = true;
			m_touchController.touchedPlayer = false;
		}

		if (m_touchController.touchedPlayer) {
			slothRigidBody.gravityScale = 5;
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

		if (!FruitBehavior.finishedLevel && sloth.transform.position.y < -7 || sloth.transform.position.y > 10
			|| sloth.transform.position.x < -14 || sloth.transform.position.x > 13) {
			print ("slothy died.");
			deathScreen.SetActive(true);
			Time.timeScale = 0;
			slothyDied = true;
		}

		if (collisionObject != null && collisionObject.tag == "jumpingBranch") {
			slothyJumping = true;
		}
		if (collisionObject != null && collisionObject.tag == "sliperyBranch") {
			slothyOnSlipery = true;
		}
		if (collisionObject != null && collisionObject.tag == "BranchWithThorns") {
			slothyOnThorns = true;
		}
		if (collisionObject != null && collisionObject.tag == "Gaizer") {
			slothyOnGaizer = true;
		}
		if (collisionObject != null && collisionObject.tag == "JumpingBranch") {
			animator.SetTrigger ("isBouncing");
		}
		if (Snake != null && (Mathf.Abs (transform.position.x - Snake.transform.position.x) == 3 && Mathf.Abs (transform.position.y - Snake.transform.position.y) < 3)) {
			snakeCloseToSloth = true;
		}
		if (Herpina != null && (Mathf.Abs (transform.position.x - Herpina.transform.position.x) == 1 && Mathf.Abs (transform.position.y - Herpina.transform.position.y) < 3)) {
			herpinaCloseToSloth = true;
		}
		if (Nest != null && (Mathf.Abs (transform.position.x - Nest.transform.position.x) == 1 && Mathf.Abs (transform.position.y - Nest.transform.position.y) < 3)) {
			nestCloseToSloth = true;
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
			slothyTouchFruit = true;
		}
	}
}
