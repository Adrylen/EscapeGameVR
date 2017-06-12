using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class CDCharger : MonoBehaviour
{

	Dictionary<string, AudioClip> audioFiles;

	public AudioSource sound;
    private string actualFileName = "";
	// Use this for initialization
	void Start()
	{
		audioFiles = new Dictionary<string, AudioClip>();

		DirectoryInfo dir = new DirectoryInfo("assets/Resources");
		FileInfo[] info = dir.GetFiles("*.mp3");

		foreach (var file in info) {
			string fileName;
			fileName = Regex.Replace(file.Name, @".mp3", "");
			audioFiles [fileName] = (AudioClip)Resources.Load (fileName);
		}

		GetComponent<AudioSource>().playOnAwake = false;
		sound = GetComponent<AudioSource>();
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
			if (other.GetComponent<CD> () != null && other. GetComponent<CD>().fileName!=actualFileName) {
				CD cd = other.GetComponent<CD> ();

				cd.gameObject.transform.parent = this.gameObject.transform;
				cd.gameObject.transform.position = this.gameObject.transform.position;
				cd.load ();
                //AudioClip clip1 = (AudioClip)Resources.Load(other.GetComponent<CD>().fileName);
				AudioClip clip1 = audioFiles[cd.fileName];

            //Debug.Log("collision");
            GameObject[] controllers = GameObject.FindGameObjectsWithTag("Controller");
            foreach(GameObject controller in controllers)
            {
                if(controller.GetComponent<ObjectInteraction>().GetTarget() == other.gameObject) {
                    controller.GetComponent<ObjectInteraction>().DetachTarget();
                    break;
                }
            }

//			if (other.GetComponent<CD> () != null && other. GetComponent<CD>().fileName!=actualFileName) {
//				CD cd = other.GetComponent<CD> ();
//
//				cd.gameObject.transform.parent = gameObject.transform;
//                cd.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
//
//                //AudioClip clip1 = (AudioClip)Resources.Load(other.GetComponent<CD>().fileName);
//                AudioClip clip1 = (AudioClip)Resources.Load(cd.fileName);
//>>>>>>> 0e1524b29c5fc1ab8a213d3025c05b02d26b9912
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
