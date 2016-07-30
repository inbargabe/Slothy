using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class NextLifeTime : MonoBehaviour {
	//public Text test_TimeNow;
	//public Text test_lastTimeDied;


	AndroidJavaClass systemClock;
	public Text timeText;
	public Text life;
	bool needToShowTime;

	public PlayerLifeController m_playerLifeController;

	void Start () {

		if (Application.platform != RuntimePlatform.Android) {
			return;
		}

		life.text = "" + GetRemainingLife();

		if (m_playerLifeController == null) {
			m_playerLifeController = GameObject.Find("GameController").GetComponent<PlayerLifeController>();	
		}


		needToShowTime = true;

		// Get the class SystemClock of android.
		try {
			systemClock = new AndroidJavaClass("android.os.SystemClock");


		} catch (Exception e) {

		}

		if (GetRemainingLife() >= m_playerLifeController.maxPlayerLife) {
			PlayerPrefs.SetInt("Remaining Player Life", m_playerLifeController.maxPlayerLife); // Change added
			//timeText.text = "infinity";
			timeText.text = "5";
			needToShowTime = false;

		} 
	}

	void Update () {
		if (Application.platform != RuntimePlatform.Android) {
			return;
		}
		if (needToShowTime) {
			m_playerLifeController.CheckIfPlayerGetLife(false);
			life.text = "" + GetRemainingLife();

			if (GetRemainingLife() >= m_playerLifeController.maxPlayerLife) {
				PlayerPrefs.SetInt("Remaining Player Life", m_playerLifeController.maxPlayerLife); // Change added
				//timeText.text = "infinity";
				timeText.text = "5";
				PlayerPrefs.SetString("Last Time User Lost Life", null);
				needToShowTime = false;
				return;
			} 
			long timeInSeconds = (m_playerLifeController.timeToGiveLife - (systemClock.CallStatic<long>("elapsedRealtime") 
				- GetLastTimeUserDied())) / 1000;
			int minutes = (int) timeInSeconds / 60;
			int seconds = (int) timeInSeconds % 60;
			string sec = "";
			string min = "";

			if (seconds < 10) {
				sec = "0" + seconds;
			} else {
				sec = "" + seconds;
			}

			if (minutes < 10) {
				min = "0" + minutes;
			} else {
				min = "" + minutes;
			}
			timeText.text = "" + min + " : " + sec; 

			//test_TimeNow.text = "" + systemClock.CallStatic<long>("elapsedRealtime");
			//test_lastTimeDied.text = "" + GetLastTimeUserDied();




		} else if (GetRemainingLife() >= m_playerLifeController.maxPlayerLife) {
			PlayerPrefs.SetInt("Remaining Player Life", m_playerLifeController.maxPlayerLife); // Change added
			//timeText.text = "infinity";
			timeText.text = "5";
			PlayerPrefs.SetString("Last Time User Lost Life", null);
			needToShowTime = false;
			return;
		}

	}


	private long GetLastTimeUserDied() {
		return System.Convert.ToInt64(PlayerPrefs.GetString("Last Time User Lost Life"));
	}

	private int GetRemainingLife() {
		return PlayerPrefs.GetInt("Remaining Player Life");
	}
}
