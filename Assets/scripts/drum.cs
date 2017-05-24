using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drum : MonoBehaviour {
	public string keyCode;


	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (keyCode)) {
			GetComponent<AudioSource> ().Play ();
		}
			
	}
}
