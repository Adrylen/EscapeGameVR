using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighPassFilter : Effect {
	public AudioHighPassFilter audioPassFilter;
	public override void ApplyEffect (float value)
	{
		float cutOffFrequency = (1-value)*2000;
		if (value >= 0.8f) {
			cutOffFrequency = 10;
		}
		audioPassFilter.cutoffFrequency = cutOffFrequency;

	}
}
