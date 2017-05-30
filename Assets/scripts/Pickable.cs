using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
	private SteamVR_TrackedController controller;
	private GameObject target = null;
	private Vector3 base_offset;
	private Vector3 offset_position;

	void OnEnable() {
		controller = GetComponent<SteamVR_TrackedController>();
	}

	void Start() {
		base_offset = new Vector3(-9999, -9999, -9999);
	}

	void Update() {
		if (controller.triggerPressed) {
			if(target != null) {
				target.transform.position = transform.position + offset_position;
			} else {
				offset_position = base_offset;
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pickable") && target == null) {
			target = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("Pickable") && target == other.gameObject) {
			target = null;
		}
	}
}
