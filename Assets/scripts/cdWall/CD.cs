using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CD : Movable
{

	private GameObject obj;
	public string fileName;
	bool loaded;
	Vector3 origin;

	void Start() {
		loaded = false;
		obj = this.gameObject;
		origin = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}

	public override void triggerClicked(){
		if (loaded) {
			transform.parent = null;
			transform.position = origin;
			loaded = false;
		}
	}

	public void load(){
		loaded = true;
	}

	void Update(){

	}
}