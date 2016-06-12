using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public AudioClip flySound;
	public AudioClip DieSound;
	public AudioClip TouchBranchSound;
	public AudioClip TouchPlayerSound;
	public AudioClip JumpingBranchSound;
	public AudioClip SnakeSound;
	public AudioClip slothyOnSlipery;
	public AudioClip SlothyOnThorns;
	public AudioClip herpinaSound;
	public AudioClip spawnFireBallSound;
	public AudioClip nestSound;
	public AudioClip slothyOnGaizerSound;
	public AudioClip FinishStageSound;


	public AudioSource audio;


	public FlyBehavior m_flyBehavior;
	public SlothBehavior m_slothBehavior;
	public TouchController m_touchController;
	public fireball m_FireBall;
	public ButtonsControl m_buttonsControl;
	public CanvasManager m_canvasManager;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if (m_flyBehavior.playerTouchedFly) {
			audio.PlayOneShot (flySound, 0.7f);
			m_flyBehavior.playerTouchedFly = false;
		}

		if (m_slothBehavior.slothyDied) {
			audio.PlayOneShot (DieSound, 0.7F);
			m_slothBehavior.slothyDied = false;
		}
		if (m_slothBehavior.slothyJumping) {
			audio.PlayOneShot (JumpingBranchSound, 0.7F);
			m_slothBehavior.slothyJumping = false;
		}
		if (m_slothBehavior.slothyOnSlipery) {
			audio.PlayOneShot (slothyOnSlipery, 0.7F);
			m_slothBehavior.slothyOnSlipery = false;
		}
		if (m_slothBehavior.slothyOnThorns) {
			audio.PlayOneShot (SlothyOnThorns, 0.7F);
			m_slothBehavior.slothyOnThorns = false;
		}
		if (m_touchController.touchedBranch) {
			audio.PlayOneShot (TouchBranchSound, 0.7f);
			//m_touchController.touchedBranch = false;
		}
		if (m_touchController.touchedPlayer) {
			audio.PlayOneShot (TouchPlayerSound, 0.7f);
			//m_touchController.touchedPlayer = false;
		}
		if (m_slothBehavior.snakeCloseToSloth) {
			audio.PlayOneShot (SnakeSound, 0.7f);
			m_slothBehavior.snakeCloseToSloth = false;
		}
		if (m_slothBehavior.herpinaCloseToSloth) {
			audio.PlayOneShot (herpinaSound, 0.7f);
			m_slothBehavior.herpinaCloseToSloth = false;
		}
		if (m_slothBehavior.nestCloseToSloth) {
			audio.PlayOneShot (nestSound, 0.7f);
			m_slothBehavior.nestCloseToSloth = false;
		}
		if (m_FireBall.spawn) {
			audio.PlayOneShot (spawnFireBallSound, 0.7f);
			m_FireBall.spawn = false;
		}
		if (m_slothBehavior.slothyOnGaizer) {
			audio.PlayOneShot (slothyOnGaizerSound, 0.7f);
			m_slothBehavior.slothyOnGaizer = false;
		}
		if (m_slothBehavior.slothyTouchFruit) {
			audio.PlayOneShot (FinishStageSound, 0.7f);
			m_slothBehavior.slothyTouchFruit = false;
		}
	}

}
