using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowPassFilter : Effect {
	public AudioLowPassFilter audioPassFilter;
	public override void ApplyEffect (float value)
	{
		float cutOffFrequency = value * 5000;
		if (value >= 0.8f) {
			cutOffFrequency = 22000;
		}
		audioPassFilter.cutoffFrequency = cutOffFrequency;

	}
}
