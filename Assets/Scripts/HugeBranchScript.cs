using UnityEngine;
using System.Collections;

public class HugeBranchScript : MonoBehaviour {

	public TouchController m_touchController;

	// Update is called once per frame
	void Update () {

		if (transform.position.x < -20f) {
			m_touchController.touchedPlayer = true;
		}
	
	}
}
