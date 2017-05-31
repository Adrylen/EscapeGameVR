using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitch : Effect {
	public override void ApplyEffect(float value){
		audioSource.pitch = value+0.5f;
	}
}
