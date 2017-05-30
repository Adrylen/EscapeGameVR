using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderVRScript : MonoBehaviour {
	private Vector3 origin;
	private float zMax = 0.5f;
	private float zMin = -0.5f;

	void Start() {
		origin = transform.localPosition;
	}

	void Update () {
		if (transform.localPosition != origin) {
			float zTemp = (transform.localPosition.z > zMax) ? zMax : (transform.localPosition.z < zMin) ? zMin : transform.localPosition.z;
			transform.localPosition = new Vector3 (origin.x, origin.y, zTemp);
		}
	}
}
