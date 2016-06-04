using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonsControl : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void onClickMainMenu(){
		SceneManager.LoadScene ("Levels");
	}

	public void onClickNextLevel(int level) {
		SceneManager.LoadScene (level + 1);
	}

	public void onClickRestart() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
}
