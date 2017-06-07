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
		GetComponent<AudioSource>().playOnAwake = false;
		sound = GetComponent<AudioSource>();
	}

	// Mettre un collider sur chacun des objets
	void OnTriggerEnter(Collider other)
	{
		SteamVR_TrackedController controller = other.GetComponentInParent<SteamVR_TrackedController>();

		if (other.gameObject.CompareTag("Pickable"))
		{
            Debug.Log("collision");
			if (other.GetComponent<CD> () != null && other.GetComponent<CD>().fileName!=actualFileName) {
                //AudioClip clip1 = (AudioClip)Resources.Load(other.GetComponent<CD>().fileName);
                AudioClip clip1 = (AudioClip)Resources.Load(other.GetComponent<CD>().fileName);
                actualFileName = other.GetComponent<CD>().fileName;
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
