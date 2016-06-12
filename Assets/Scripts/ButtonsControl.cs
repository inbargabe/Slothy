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
		audio.PlayOneShot (clickSound, 0.7f);
		SceneManager.LoadScene (0);
	}

	public void onClickNextLevel() {
		audio.PlayOneShot (clickSound, 0.7f);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void onClickRestartButton(){
		audio.PlayOneShot (clickSound, 0.7f);
		Time.timeScale = 1;
		pauseScreen.SetActive(false);
		endOfStageScreen.SetActive (false);
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
	}

	public void onClickRestartWhenDiedButton(){
		audio.PlayOneShot (clickSound, 0.7f);
		Time.timeScale = 1;
		deathScreen.SetActive(false);
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
	}

	public void onClickResume() {
		audio.PlayOneShot (clickSound, 0.7f);
		Time.timeScale = 1;
		pauseScreen.SetActive(false);
	}
		
	public void onClickPauseButton(){
		audio.PlayOneShot (clickSound, 0.7f);
		Time.timeScale = 0;
		pauseScreen.SetActive(true);
	}

}
