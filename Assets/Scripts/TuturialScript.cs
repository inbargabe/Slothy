using UnityEngine;
using System.Collections;

public class TuturialScript : MonoBehaviour {

	public GameObject tuturial;

	public GameObject meetSloth;
	public GameObject meetFruit;
	public GameObject meetBranches;
	public GameObject meetEnemies;
	public GameObject meetFlies;

	public bool isFirstTime;
	void Update(){
		if (isFirstTime) {
			tuturial.SetActive (true);
		}

	}
	public void onClickNextMeetSloth() {
		meetSloth.SetActive (false);
		meetFruit.SetActive (true);
	}

	public void onClickNextMeetFruit() {
		meetFruit.SetActive(false);
		meetBranches.SetActive (true);
	}

	public void onClickNextMeetBranches() {
		meetBranches.SetActive(false);
		meetEnemies.SetActive(true);
	}

	public void onClickNextMeetEnemies() {
		meetEnemies.SetActive(false);
		meetFlies.SetActive(true);
	}

	public void onClickNextMeetFlies() {
		meetFlies.SetActive(false);
		tuturial.SetActive(false);
	}
}
