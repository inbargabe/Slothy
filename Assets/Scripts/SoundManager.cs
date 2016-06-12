using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public AudioClip flySound1;
	public AudioSource audio;

	FlyBehavior m_flyBehavior;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if (m_flyBehavior.playerTouchedFly) {
			audio.PlayOneShot (flySound1, 0.7f);
			m_flyBehavior.playerTouchedFly = false;
		}
		
	}
	void OnTriggerEnter2D(Collider2D objectCollision) {

		if (objectCollision.gameObject.tag == "Fly") {
			audio.PlayOneShot (flySound1, 0.7F);



		}

	}
}
