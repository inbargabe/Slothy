﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject levelMenu;
	public GameObject settings;
	public GameObject loadingImage;
	public GameObject credits;


	public int numOfLevels; 

	void Start () {
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
		//SetSoundOnOff();

	}


	public void FlyCount() {
		for (int i = 0; i < numOfLevels; i++) {
			Transform Flies = levelMenu.transform.GetChild (i + 1).GetChild (1).GetChild (1);
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
			if (PlayerPrefs.GetInt("levelNumber") >= i) {
				levelMenu.transform.GetChild(i + 1).GetComponent<Button>().interactable = true;
			} else {
				levelMenu.transform.GetChild(i + 1).GetComponent<Button>().interactable = false;
			}
		}
	}

	public void onClickBeginButton() {
		mainMenu.SetActive(false);
		levelMenu.SetActive(true);
	}


	public void onClickLevelButton(int level) {
		loadingImage.SetActive(true);
		levelMenu.SetActive (false);
		SceneManager.LoadSceneAsync(level, LoadSceneMode.Single);

	}
		

	public void onClickBackButton (string button) {
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
		settings.SetActive(true);
		mainMenu.SetActive(false);
	}

	public void onClickResetButton (){
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt("Show_Level", 1);
		SetLevels();
		FlyCount();
		//SetSoundOnOff();
	}

	public void onClickCreditsButton () {
		credits.SetActive(true);
		mainMenu.SetActive(false);
	}
}