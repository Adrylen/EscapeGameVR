using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderVRScript : MonoBehaviour {
	private float sliderValue=0;
	private float sliderPosition =-0.5f;
	public float maxPos = 0.5f;
	public float minPos = -0.5f;

	private float sliderValueToPos(){
		return sliderValue - 0.5f;
	}

	private void updatePosition(){
		Debug.Log (sliderValueToPos ());
		if (sliderValueToPos () >= minPos && sliderValueToPos () <= maxPos) {
				sliderPosition = sliderValueToPos ();
		}
		transform.localPosition = new Vector3 (0.0f, 0.0f, sliderPosition);
	}

	void Start () {
		updatePosition ();
	}
	
	// Update is called once per frame
	void Update () {
		sliderValue += 0.001f;
		updatePosition ();
	}
}
