using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movable : MonoBehaviour {
	public void leaveInput(){}
	public void enterInout(){}
    public abstract void Movement(GameObject controller);
}
