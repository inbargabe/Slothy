﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pointsManager : MonoBehaviour {

	public static int flies;

	public Image flyBar;
	public Image flyBarEndOfscene;

	// Use this for initialization
	void Start () {
		flies = 0;
	}

	void Update() {
		
		switch (flies) {

		case 0:
			flyBar.fillAmount = 0f;
			flyBarEndOfscene.fillAmount = 0f;
			break;
		
		case 1:
			flyBar.fillAmount = 0.33f;
			flyBarEndOfscene.fillAmount = 0.33f;
			break;

		case 2:
			flyBar.fillAmount = 0.67f;
			flyBarEndOfscene.fillAmount = 0.67f;
			break;

		case 3:
			flyBar.fillAmount = 1f;
			flyBarEndOfscene.fillAmount = 1f;
			break;

		default:
			flyBar.fillAmount = 0f;
			flyBarEndOfscene.fillAmount = 0f;
			break;
		}
	}

}
