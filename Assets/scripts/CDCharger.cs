using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDCharger : MonoBehaviour
{
	public AudioSource sound;
    private string actualFileName = "";
	// Use this for initialization
	void Start()
	{
        //GetComponent<AudioSource>().playOnAwake = false;
        //sound = GetComponent<AudioSource>();
        sound.playOnAwake = false;
    }

	// Mettre un collider sur chacun des objets
	void OnTriggerEnter(Collider other)
	{
        //SteamVR_TrackedController controller = other.GetComponentInParent<SteamVR_TrackedController>();

		if (other.gameObject.CompareTag("Pickable"))
		{
            //Debug.Log("collision");
            GameObject[] controllers = GameObject.FindGameObjectsWithTag("Controller");
            foreach(GameObject controller in controllers)
            {
                if(controller.GetComponent<ObjectInteraction>().GetTarget() == other.gameObject) {
                    controller.GetComponent<ObjectInteraction>().DetachTarget();
                    break;
                }
            }

			if (other.GetComponent<CD> () != null && other. GetComponent<CD>().fileName!=actualFileName) {
				CD cd = other.GetComponent<CD> ();

				cd.gameObject.transform.parent = gameObject.transform;
                cd.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                //AudioClip clip1 = (AudioClip)Resources.Load(other.GetComponent<CD>().fileName);
                AudioClip clip1 = (AudioClip)Resources.Load(cd.fileName);
                actualFileName = cd.fileName;
                sound.Stop();
                sound.PlayOneShot(clip1);

                if(clip1 == null)
                {
                    Debug.Log("Problème chargement cd dans CDCharger");
                }
			}
			//SteamVR_Controller.Input((int)controller.controllerIndex).TriggerHapticPulse((ushort)3999);
		}
	}
}
