using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleEmission : MonoBehaviour {
	public ParticleSystem system;
	// Use this for initialization
	void Start () {
		system.Stop ();
		//InvokeRepeating("DoEmit", 2.0f, 2.0f);
	}

	void DoEmit(float[] spectrum)
	{
		var emitParams = new ParticleSystem.EmitParams();
		emitParams.startColor = new Color(spectrum[0]*10, spectrum[1]*10,0, spectrum[2]*10);
		emitParams.startSize = 0.3f;
		emitParams.velocity = new Vector3(0, 0, Random.Range(2f, 5.0f)*spectrum[1]*17);
		system.Emit(emitParams, 5);
		//system.Play();
	}
	
	// Update is called once per frame
	void Update () {
		float[] spectrum = fft.makeFft (8, 1024);
		if (spectrum [1] > 0.05) {
			DoEmit (spectrum);
		}
	}
}
