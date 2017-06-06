using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {
    public virtual void Movement(Object controller) {}
    public virtual void Movement(GameObject controller) {}
    public virtual void leaveInput() { }
    public virtual void enterInput() { }
    public virtual void triggerClicked() { }
    public virtual void PadClicked() { }
    public virtual void PadReleased() { }
}
