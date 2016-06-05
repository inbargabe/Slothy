using UnityEngine;
using System.Collections;

public class endBranchBehavior : MonoBehaviour {

	public GameObject sloth;
	public GameObject branch1;

	BoxCollider2D branchCollider;

	// Use this for initialization
	void Start () {
		sloth = GameObject.Find ("sloth");
		branchCollider = branch1.GetComponent<BoxCollider2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (sloth.transform.position.y - transform.position.y > 0.6) {
			branchCollider.isTrigger = false;
		}
	}
}
