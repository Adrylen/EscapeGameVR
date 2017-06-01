using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableButton : Movable {
	public bool active;

	private Vector3 origin;
	private bool outFlag;

	// Use this for initialization
	void Start () {
		active = false;
		outFlag = true;
		origin = transform.localPosition;
	}

	public override void enterInput(){
		outFlag = false;
	}

	public override void leaveInput(){
		outFlag = true;
	}

	public override void Movement(GameObject controller) {
		if (outFlag) {
			active = !active;
		}

		if (active) {
			transform.localPosition = new Vector3 (origin.x, origin.y - 0.01f, origin.z);
		} else {
			transform.localPosition = new Vector3 (origin.x, origin.y, origin.z);
		}					
	}
}
