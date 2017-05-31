using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : Effect {
	public override void ApplyEffect (float value)
	{
		audioSource.volume = value;

	}
}
