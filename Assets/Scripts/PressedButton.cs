using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PressedButton : MonoBehaviour {
	
	public GameObject onButton; 
	public Sprite onPressedButtonImage;
	public Sprite onNotPressedbuttonImage;
	Image onButtonImage;

	public GameObject offButton; 
	public Sprite offPressedButtonImage;
	public Sprite offNotPressedbuttonImage; 
	Image offButtonImage;


	public bool clicked;

	// Use this for initialization
	void Start () {
		clicked = false; 
		onButtonImage = onButton.GetComponent<Image> ();
		offButtonImage = offButton.GetComponent<Image> ();

	}
	
	// Update is called once per frame
	public void OnClickMusicButton () {
		if (PlayerPrefs.GetInt("MuteMusic") == 0) {
			onButtonImage.sprite = onPressedButtonImage;
			offButtonImage.sprite = offNotPressedbuttonImage;
			//clicked = false;
		} else {
			onButtonImage.sprite = onNotPressedbuttonImage;
			offButtonImage.sprite = offPressedButtonImage;
			//clicked = true; 
		}
	}

	public void OnClickSoundButton () {
		if (PlayerPrefs.GetInt("MuteSounds") == 0) {
			onButtonImage.sprite = onPressedButtonImage;
			offButtonImage.sprite = offNotPressedbuttonImage;
			//clicked = false;
		} else {
			onButtonImage.sprite = onNotPressedbuttonImage;
			offButtonImage.sprite = offPressedButtonImage;
			//clicked = true; 
		}
	}
}
