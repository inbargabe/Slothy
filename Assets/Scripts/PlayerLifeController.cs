using UnityEngine;
using System.Collections;
using System;

public class PlayerLifeController : MonoBehaviour {

	public GameObject NoMoreLivesScreen;



	// TODO: Attach this script to main menu.

	public int maxPlayerLife = 1000000;


	// 1000 is one second.
	public long timeToGiveLife = 1000 * 60 * 15;

	AndroidJavaClass systemClock;


	void Start () {



		if (Application.platform != RuntimePlatform.Android) {
			return;
		}

		// Get the class SystemClock of android.
		try {
			systemClock = new AndroidJavaClass("android.os.SystemClock");
			long a = systemClock.CallStatic<long>("elapsedRealtime");

		} catch (Exception e) {

		}



		// do only when first entering the game.
		if (PlayerPrefs.GetInt("FirstStart") == 0) {
			PlayerPrefs.SetInt("FirstStart", 1);

			PlayerPrefs.SetInt("Remaining Player Life", maxPlayerLife);

		} else if (PlayerPrefs.GetInt("Remaining Player Life") < maxPlayerLife) {

			if (GetLastTimeUserDied() > systemClock.CallStatic<long>("elapsedRealtime")) {
				long temp = systemClock.CallStatic<long>("elapsedRealtime");
				PlayerPrefs.SetString("Last Time User Lost Life", "" + temp);

			} else {
				CheckIfPlayerGetLife(false);	
			}


		}


		if (PlayerPrefs.GetInt("Remaining Player Life") <= 0 && NoMoreLivesScreen != null) {
			PlayerPrefs.SetInt("Remaining Player Life", 0);
			NoMoreLivesScreen.SetActive(true);
			Time.timeScale = 0;
		} else {
			NoMoreLivesScreen.SetActive(false);
		}




	}


	public void CheckIfPlayerGetLife(bool hasChanged) {
		if (Application.platform != RuntimePlatform.Android) {
			return;
		}


		if (hasChanged) {
			return;
		}

		bool hasNotChangedIn = true;

		if (PlayerPrefs.GetString("Last Time User Lost Life") != null) {

			if (GetLastTimeUserDied() < systemClock.CallStatic<long>("elapsedRealtime") - timeToGiveLife) {
				hasNotChangedIn = false;

				if (GetRemainingLife() < maxPlayerLife) {


					PlayerPrefs.SetInt("Remaining Player Life", GetRemainingLife() + 1);

					long temp = 0;
					if (GetLastTimeUserDied() > systemClock.CallStatic<long>("elapsedRealtime")) {
						temp = systemClock.CallStatic<long>("elapsedRealtime");
					} else {
						temp = timeToGiveLife + GetLastTimeUserDied();	
					}


					PlayerPrefs.SetString("Last Time User Lost Life", "" + temp);

				} else {
					PlayerPrefs.SetString("Last Time User Lost Life", null);
					return;
				}
			}
		}

		CheckIfPlayerGetLife(hasNotChangedIn);
	}

	private long GetLastTimeUserDied() {
		return System.Convert.ToInt64(PlayerPrefs.GetString("Last Time User Lost Life"));
	}

	private int GetRemainingLife() {
		return PlayerPrefs.GetInt("Remaining Player Life");
	}



	public void PlayerDied() {
		if (Application.platform != RuntimePlatform.Android) {
			return;
		}

		if (GetRemainingLife() == 0) {
			return;
		}

		if (PlayerPrefs.GetInt("Remaining Player Life") == maxPlayerLife) {

			PlayerPrefs.SetString("Last Time User Lost Life", "" + systemClock.CallStatic<long>("elapsedRealtime"));

		} 

		PlayerPrefs.SetInt("Remaining Player Life", GetRemainingLife() - 1);

	}
}
