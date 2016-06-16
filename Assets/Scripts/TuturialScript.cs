using UnityEngine;
using System.Collections;

public class TuturialScript : MonoBehaviour {

	public GameObject tuturial;

	public GameObject meetSloth;
	public GameObject meetFruit;
	public GameObject meetBranches;
	public GameObject meetAbilities;
	public GameObject meetEnemies;
	public GameObject meetFlies;


	// sound
	public AudioClip clickSound;
	public AudioSource audio;

	public bool isFirstTime;

	void Update(){
		if (isFirstTime) {
			tuturial.SetActive (true);
		}

	}
	public void onClickNextMeetSloth() {
		meetSloth.SetActive (false);
		meetFruit.SetActive (true);
		audio.PlayOneShot (clickSound, 0.7f);
	}

	public void onClickNextMeetFruit() {
		meetFruit.SetActive(false);
		meetBranches.SetActive(true);
		audio.PlayOneShot (clickSound, 0.7f);
	}

	public void onClickNextMeetBranches() {
		meetBranches.SetActive(false);
		meetAbilities.SetActive(true);
		audio.PlayOneShot (clickSound, 0.7f);
	}

	public void onClickNextMeetAbilities() {
		meetAbilities.SetActive (false);
		meetEnemies.SetActive (true);
		audio.PlayOneShot (clickSound, 0.7f);
	}

	public void onClickNextMeetEnemies() {
		meetEnemies.SetActive(false);
		meetFlies.SetActive(true);
		audio.PlayOneShot (clickSound, 0.7f);
	}

	public void onClickNextMeetFlies() {
		meetFlies.SetActive(false);
		tuturial.SetActive(false);
		audio.PlayOneShot (clickSound, 0.7f);
	}

	public void onClickSkipTuturial() {
		tuturial.SetActive(false);
		audio.PlayOneShot (clickSound, 0.7f);
	}
}
