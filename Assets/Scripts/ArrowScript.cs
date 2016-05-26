using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

	public GameObject arrow;
	SpriteRenderer arrowSpriteRenderer;

	public TouchController m_touchController;

	// Use this for initialization
	void Start () {
		arrowSpriteRenderer = arrow.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (m_touchController.firstArrow > 0) {
			arrowSpriteRenderer.enabled = false;
		}
	}
}
