using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pointsManager : MonoBehaviour {

	public static int flies;

	public Image flyBar;

	// Use this for initialization
	void Start () {
		flies = 0;
	}

	void Update() {
		
		switch (flies) {

		case 0:
			flyBar.fillAmount = 0f;
			break;
		
		case 1:
			flyBar.fillAmount = 0.33f;
			break;

		case 2:
			flyBar.fillAmount = 0.67f;
			break;

		case 3:
			flyBar.fillAmount = 1f;
			break;

		default:
			flyBar.fillAmount = 0f;
			break;
		}
	}

	/*
	public void FlyCount() {

		string level = "MaxFliesOfLevel" + SceneManager.GetActiveScene ().buildIndex;

		print("level" + level);

		//TODO: display how many stars collected in level menu.
		if (flies > PlayerPrefs.GetInt (level)) {
			PlayerPrefs.SetInt (level, flies);
		} 
	}*/
		

}
