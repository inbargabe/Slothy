using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonsControl : MonoBehaviour {

	public GameObject pauseScreen;
	public GameObject endOfStageScreen;
	public GameObject deathScreen; 

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

	public void onClickRestartButton(){
		Time.timeScale = 1;
		pauseScreen.SetActive(false);
		endOfStageScreen.SetActive (false);
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
	}

	public void onClickRestartWhenDiedButton(){
		Time.timeScale = 1;
		deathScreen.SetActive(false);
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
	}

	public void onClickResume() {
		Time.timeScale = 1;
		pauseScreen.SetActive(false);
	}
		
	public void onClickPauseButton(){
		Time.timeScale = 0;
		pauseScreen.SetActive(true);
	}

}
