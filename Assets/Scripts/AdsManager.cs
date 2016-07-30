using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
	public GameObject NoMoreLivesScreen;
	int counter;


	void Start(){
		counter = 0;
	}

	void Update(){
		if (counter == 2) {
			counter = 0;
			NoMoreLivesScreen.SetActive(false);
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