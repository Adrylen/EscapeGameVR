using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CD : Movable
{

	private GameObject obj;
	public string fileName;

	void Start() {
		obj = this.gameObject;

		Debug.Log (obj.name);

	}

	void Update(){

	}
}