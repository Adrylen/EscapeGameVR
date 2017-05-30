using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderScript : MonoBehaviour
{
    Vector3 startSliderButtonPosition = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 incDecSlid = new Vector3(0, 0, 0.05f);
    Vector3 slidLimit = new Vector3(0, 0, 0.5F);
    public float y;

    void Start()
    {
        transform.position = startSliderButtonPosition; // Initialisation du bouton
    }

    void LateUpdate()
    {
        if (hasMouseMoved() && Input.GetMouseButton(0))
        {
            if (transform.position != slidLimit && Input.GetAxis("Mouse Y") > 0)
                transform.position += Input.GetAxis("Mouse Y") * incDecSlid;
            else if (transform.position != -slidLimit && Input.GetAxis("Mouse Y") < 0)
                transform.position += Input.GetAxis("Mouse Y") * incDecSlid;
        }
    }

    bool hasMouseMoved()
    {
        return (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0);
    }

}

