using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BranchWithThornsCode : MonoBehaviour {
		
	void OnCollisionEnter2D(Collision2D objectCollision) {

		if (objectCollision.gameObject.tag == "Player") {
			SceneManager.LoadScene (1);		
		}
	}
}
