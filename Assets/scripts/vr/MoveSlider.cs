using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlider : Movable {
	private Vector3 origin;
	private float zMax = 0.5f;
	private float zMin = -0.5f;

	void Start() {
		origin = transform.localPosition;
	}
//
//	void Update () {
//		if (transform.localPosition != origin) {
//			float zTemp = (transform.localPosition.z > zMax) ? zMax : (transform.localPosition.z < zMin) ? zMin : transform.localPosition.z;
//			transform.localPosition = new Vector3 (origin.x, origin.y, zTemp);
//		}
//	}
//
	public void Movement(Vector3 position) {
		if (transform.localPosition != origin) {
			float zTemp = (transform.localPosition.z > zMax) ? zMax : (transform.localPosition.z < zMin) ? zMin : transform.localPosition.z;
			transform.localPosition = new Vector3 (origin.x, origin.y, zTemp);
		}
	}
}
