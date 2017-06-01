using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumStick : Movable {
    public Rigidbody rBody;
    private SteamVR_TrackedController controllerButton;
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }
    

    public override void Movement(Object controller){
        if(((SteamVR_TrackedController)controller).triggerPressed) {
            rBody.useGravity = false;
            transform.parent = ((GameObject)controller).transform;
            transform.localEulerAngles = new Vector3(0, 0, 0);
            transform.localPosition = new Vector3(0, 0, 1);
        }
    }


    public bool isAlreadyGrabbed()
    {
        return transform.parent.CompareTag("Controller");
    }
}
