using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
			PlayerPrefs.SetInt("Remaining Player Life", PlayerPrefs.GetInt("Remaining Player Life")+ 1);
		}
	}
}