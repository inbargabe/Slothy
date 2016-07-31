using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
	public GameObject NoMoreLivesScreen;
	public GameObject deathScreen;
	int counter;


	void Start(){
		counter = 0;
	}

	void Update(){
		if (counter == 1) {
			counter = 0;
			NoMoreLivesScreen.SetActive(false);
			deathScreen.SetActive (true);
		}
	}
	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
			counter++;
			PlayerPrefs.SetInt("Remaining Player Life", PlayerPrefs.GetInt("Remaining Player Life")+ 1);
		}
	}
}