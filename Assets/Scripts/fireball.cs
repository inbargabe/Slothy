using UnityEngine;
using System.Collections;

public class fireball : MonoBehaviour {

	public float leftRightSpeed;
	public GameObject ball;
	public float spawnTime = 5f;
	public bool isGoingRight;

	public bool spawn;


	// Use this for initialization
	void Start () {
		//Move (isGoingRight);
		InvokeRepeating ("SpawnBall", spawnTime, spawnTime);
		spawn = false;

	}
		    
	void SpawnBall()
	{
		if (ball != null) {
			var newBall = GameObject.Instantiate (ball);
			spawn = true;
		}
	}

	/**void Move(bool isGoingRight)
	{
		//float movementX = isGoingRight ? leftRightSpeed : -leftRightSpeed;
		float movementX = -leftRightSpeed;
		transform.Translate (new Vector3 (movementX * Time.deltaTime, 0, 0));
	}**/

	/*
	void OnCollisionEnter2D(Collision2D objectCollision)
	{
		if (objectCollision.gameObject.tag == "Player") {
			//	Destroy (gameObject);
			Application.LoadLevel("LoseLevel");

		}
	}
	*/
}
