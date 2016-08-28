using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject levelMenu;
	public GameObject settings;
	public GameObject loadingImage;
	public GameObject credits;

	//Sound
	public AudioClip clickSound;
	public AudioSource audio;


	public int numOfLevels; 


	void Start () {
		audio = GetComponent<AudioSource>();
		//audioSource = GetComponent<AudioSource>();
		// set scroll for showing level at start of every level.
		//PlayerPrefs.SetInt("Show_Level", 1); 
		if (FruitBehavior.finishedLevel) {
			levelMenu.SetActive(true);
			mainMenu.SetActive(false);
			FruitBehavior.finishedLevel = false;
		} else {
			mainMenu.SetActive(true);
		}
		SetLevels();
		FlyCount();
		setSoundsOnOff();
	}


	public void FlyCount() {
		for (int i = 0; i < numOfLevels; i++) {
			Transform Flies = levelMenu.transform.GetChild (i + 1).GetChild (0).GetChild (1);
			FillStars (Flies.GetComponent<Image>(), i + 1);
		}
	}

	public void FillStars(Image Flies, int level) {
		print("flies for a level " + PlayerPrefs.GetInt("MaxFliesOfLevel" + level));
		switch (PlayerPrefs.GetInt ("MaxFliesOfLevel" + level)) {
		case 0: 
			Flies.fillAmount = 0f;
			break;
		case 1:
			Flies.fillAmount = 0.33f;
			break;
		case 2:
			Flies.fillAmount = 0.68f;			
			break;
		case 3:
			Flies.fillAmount = 1f;
			break;
		}

	}

	public void SetLevels() {
		print(PlayerPrefs.GetInt("levelNumber"));
		for(int i = 0; i < numOfLevels ; i++) {
			//cheat for eran and roie
			/*
			if (PlayerPrefs.GetInt("levelNumber") >= i) {
				levelMenu.transform.GetChild(i + 1).GetComponent<Button>().interactable = true;
			} else {
				levelMenu.transform.GetChild(i + 1).GetComponent<Button>().interactable = false;
			}
*/
		}

	}

	public void onClickBeginButton() {
		audio.PlayOneShot (clickSound, 0.7f);
		mainMenu.SetActive(false);
		levelMenu.SetActive(true);
	}


	public void onClickLevelButton(int level) {
		audio.PlayOneShot (clickSound, 0.7f);
		loadingImage.SetActive(true);
		levelMenu.SetActive (false);
		SceneManager.LoadSceneAsync(level, LoadSceneMode.Single);

	}
		

	public void onClickBackButton (string button) {
		audio.PlayOneShot (clickSound, 0.7f);
		switch(button) {
		case "LevelMenu":
			mainMenu.SetActive(true);
			levelMenu.SetActive(false);
			break;
		case "Settings":
			mainMenu.SetActive(true);
			settings.SetActive(false);
			break;
		case "Credits": 
			mainMenu.SetActive(true);
			credits.SetActive(false);
			break;
		}

	}

	public void onClickSettingsButton () {
		audio.PlayOneShot (clickSound, 0.7f);
		settings.SetActive(true);
		mainMenu.SetActive(false);
	}

	public void onClickResetButton (){
		audio.PlayOneShot (clickSound, 0.7f);
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt("Show_Level", 1);
		SetLevels();
		FlyCount();
		setSoundsOnOff();
	}

	public void onClickCreditsButton () {
		audio.PlayOneShot (clickSound, 0.7f);
		credits.SetActive(true);
		mainMenu.SetActive(false);
	}

	public void onClickSoundsON() {
		PlayerPrefs.SetInt ("MuteSounds", 0);
		setSoundsOnOff ();
	}

	public void onClickSoundsOFF() {
		PlayerPrefs.SetInt ("MuteSounds", 1);
		setSoundsOnOff ();
	}

	public void onClickMusicON() {
		PlayerPrefs.SetInt ("MuteMusic", 0);
		setSoundsOnOff ();
	}

	public void onClickMusicOFF() {
		PlayerPrefs.SetInt ("MuteMusic", 1);
		setSoundsOnOff ();
	}

	public void setSoundsOnOff() {
		if (PlayerPrefs.GetInt ("MuteMusic") == 0) {
			audio.Play ();
		} else {
			audio.Stop ();
		}
	}
}
