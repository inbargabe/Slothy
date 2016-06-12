using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonsControl : MonoBehaviour {

	public GameObject pauseScreen;
	public GameObject endOfStageScreen;
	public GameObject deathScreen; 

	//Sound
	public AudioClip clickSound;
	public AudioSource audio;



	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void onClickMainMenu(){
		SceneManager.LoadScene (0);
		audio.PlayOneShot (clickSound, 0.7f);
	}

	public void onClickNextLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		audio.PlayOneShot (clickSound, 0.7f);
	}

	public void onClickRestartButton(){
		Time.timeScale = 1;
		pauseScreen.SetActive(false);
		endOfStageScreen.SetActive (false);
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
		audio.PlayOneShot (clickSound, 0.7f);
	}

	public void onClickRestartWhenDiedButton(){
		Time.timeScale = 1;
		deathScreen.SetActive(false);
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
		audio.PlayOneShot (clickSound, 0.7f);
	}

	public void onClickResume() {
		Time.timeScale = 1;
		pauseScreen.SetActive(false);
		audio.PlayOneShot (clickSound, 0.7f);
	}
		
	public void onClickPauseButton(){
		Time.timeScale = 0;
		pauseScreen.SetActive(true);
		audio.PlayOneShot (clickSound, 0.7f);
	}

}
