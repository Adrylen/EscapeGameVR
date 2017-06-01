using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
	private SteamVR_TrackedController controller;
	private GameObject target = null;
	private Vector3 base_offset;
	private Vector3 offset_position;

    public int pulsation = 900;

	void OnEnable() {
		controller = GetComponent<SteamVR_TrackedController>();
	}

	void Start() {
		base_offset = new Vector3(-9999, -9999, -9999);
        offset_position = base_offset;
	}

	void Update() {
		if (controller.triggerPressed) {
			if(target != null) {
                if(offset_position == base_offset) {
                    offset_position = target.transform.position - transform.position;
                }
                if(target.GetComponent<Movable>() != null) {
                    target.GetComponent<Movable>().Movement(gameObject);
                }
			} else {
				offset_position = base_offset;
			}
		} else {
            if(target != null) {
                if (target.GetComponent<Movable>() != null) {
                    target.GetComponent<Movable>().leaveInput();
                }
            }
        }
	}

	void OnTriggerEnter(Collider other) {
        SteamVR_Controller.Input((int)controller.controllerIndex).TriggerHapticPulse((ushort)pulsation);
        if (other.gameObject.CompareTag("Pickable") && target == null) {
			target = other.gameObject;
            if (target.GetComponent<Movable>() != null) {
                target.GetComponent<Movable>().enterInput();
            }
		}
        if(other.gameObject.CompareTag("DrumStick") && target == null) {
            if(!other.gameObject.GetComponent<DrumStick>().isAlreadyGrabbed()) {
                target = other.gameObject;
            }
        }
	}
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pickable") && target == other.gameObject)
        {
            if (target.GetComponent<Movable>() != null)
            {
                target.GetComponent<Movable>().leaveInput();
            }
            target = null;
        }
        if (other.gameObject.CompareTag("DrumStick") && target == other.gameObject){
            if (!other.gameObject.GetComponent<DrumStick>().isAlreadyGrabbed()){
                target = null;
            }
        }
    }
}
