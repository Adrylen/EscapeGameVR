using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableButton : Movable {
	private Vector3 origin;
	private bool active;

	// Use this for initialization
	void Start () {
		active = false;
		origin = transform.localPosition;
	}

	public override void Movement(GameObject controller) {
		active = !active;
		if (active) {
			transform.localPosition = new Vector3 (origin.x, origin.y - 0.5f, origin.z);
		} else {
			transform.localPosition = new Vector3 (origin.x, origin.y, origin.z);
		}					
	}
}
