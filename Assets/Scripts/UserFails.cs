using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UserFails : MonoBehaviour {

	public GameObject sloth;

	public FruitBehavior m_fruitBehavior;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (sloth.transform.position.y < -7 || sloth.transform.position.y > 10
			|| sloth.transform.position.x < -12.76 || sloth.transform.position.x > 13) {
			print ("slothy died.");
			SceneManager.LoadScene ("LoseLevel");
		}

	}
}
