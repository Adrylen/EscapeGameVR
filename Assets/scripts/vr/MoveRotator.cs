using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRotator : Movable {
    private float yMax = 150.0F;
    private float yMin = -150.0F;
    private float speedRot = 3.0F;
    private Quaternion origin;
    private Vector3 vecTransition;

    void Start () {
        origin = transform.parent.localRotation;
        vecTransition = transform.parent.localEulerAngles;
    }

    public override void Movement(GameObject controller)
    {
        transform.parent.rotation = controller.transform.rotation;
        if (transform.parent.localRotation != origin)
        {
            float yVal;
            yVal = (transform.parent.localEulerAngles.y > yMax) ? yMax : (transform.parent.localEulerAngles.y < yMin) ? yMin : transform.parent.localEulerAngles.y;
            transform.parent.localRotation = Quaternion.Euler(vecTransition.x, yVal, vecTransition.z);
            gameObject.GetComponentInParent<Effect>().ApplyEffect(yVal + 150.0F);
        }
    }
}

