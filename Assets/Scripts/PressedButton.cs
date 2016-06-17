using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PressedButton : MonoBehaviour {
	/*
	public GameObject onButton; 
	public Sprite onPressedButtonImage;
	public Sprite onNotPressedbuttonImage;
	Image onButtonImage;

	public GameObject offButton; 
	public Sprite offPressedButtonImage;
	public Sprite offNotPressedbuttonImage; 
	Image offButtonImage;
	*/

	public Image onSound; 
	public Image offSound;
	public Sprite onPressedSoundSprite;
	public Sprite onNotPressedSoundSprite;
	public Sprite offPressedSoundSprite;
	public Sprite offNotPressedSoundSprite;

	public Image onMusic; 
	public Image offMusic;
	public Sprite onPressedMusicSprite;
	public Sprite onNotPressedMusicSprite;
	public Sprite offPressedMusicSprite;
	public Sprite offNotPressedMusicSprite;



	public bool clicked;

	// Use this for initialization
	void Start () {
		clicked = false; 
		//onButtonImage = onButton.GetComponent<Image> ();
		//offButtonImage = offButton.GetComponent<Image> ();
		SetSoundButtons ();
	}
	
	// Update is called once per frame
	public void OnClickMusicButton () {
		if (PlayerPrefs.GetInt("MuteMusic") == 0) {
			onMusic.sprite = onPressedMusicSprite;
			offMusic.sprite = offNotPressedMusicSprite;
			//clicked = false;
		} else {
			onMusic.sprite = onNotPressedMusicSprite;
			offMusic.sprite = offPressedMusicSprite;
			//clicked = true; 
		}
	}

	public void OnClickSoundButton () {
		if (PlayerPrefs.GetInt("MuteSounds") == 0) {
			onSound.sprite = onPressedSoundSprite;
			offSound.sprite = offNotPressedSoundSprite;
			//clicked = false;
		} else {
			onSound.sprite = onNotPressedSoundSprite;
			offSound.sprite = offPressedMusicSprite;
			//clicked = true; 
		}
	}

	public void SetSoundButtons(){
		if (PlayerPrefs.GetInt ("MuteSounds") == 0) {
			onSound.sprite = onPressedSoundSprite;
			offSound.sprite = offNotPressedSoundSprite;
		} else {
			onSound.sprite = onNotPressedSoundSprite;
			offSound.sprite = offPressedMusicSprite;
		}

		if (PlayerPrefs.GetInt ("MuteMusic") == 0) {
			onMusic.sprite = onPressedMusicSprite;
			offMusic.sprite = offNotPressedMusicSprite;
		} else {
			onMusic.sprite = onNotPressedMusicSprite;
			offMusic.sprite = offPressedMusicSprite;
		}
	}
}
