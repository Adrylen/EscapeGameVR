using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Primitive : MonoBehaviour {
	private SteamVR_TrackedController controller;
	private GameObject target = null;
	//private bool triggered;

	public TextMesh text;

	private void OnEnable() {
		controller = GetComponent<SteamVR_TrackedController> ();
		controller.TriggerClicked += HandleTriggerClicked;
		controller.PadClicked += HandlePadClicked;
	}

	private void OnDisable() {
		controller.TriggerClicked -= HandleTriggerClicked;
		controller.PadClicked -= HandlePadClicked;
	}

	#region Enter Collider
	void OnTriggerEnter(Collider other) {
		if (target == null) {
			target = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other) {
		if (target == other.gameObject) {
			target = null;
		}
	}
	#endregion

	#region Trigger
	private void HandleTriggerClicked(object sender, ClickedEventArgs e) {
		text.text = "Trigger";
	}
	#endregion

	#region Pad
	private void HandlePadClicked(object sender, ClickedEventArgs e) {
		text.text = "Pad";
	}
	#endregion
}
