using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public AudioClip flySound1;

	public AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D objectCollision) {

		if (objectCollision.gameObject.tag == "Fly") {
			audio.PlayOneShot (flySound1, 0.7F);



		}

	}
}
