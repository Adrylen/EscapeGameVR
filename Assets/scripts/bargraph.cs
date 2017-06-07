using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bargraph : MonoBehaviour {
	public GameObject templateRod;
	public int numberOfFrequencies;
	public int numberOfDecomposition = 4;

	public float slider;
	private GameObject[] rods;
	private float[] spectrumDecomposition;

	void Start () {
		CheckNumberOfDecomposition ();
		Quaternion origin_rotation = gameObject.transform.rotation;
		gameObject.transform.rotation = new Quaternion (0, 0, 0, 0);

		spectrumDecomposition = new float[numberOfDecomposition];
		rods = new GameObject[numberOfDecomposition];

		for (int i = 0; i < numberOfDecomposition; i++) {
			rods[i] = Instantiate (templateRod);
			rods[i].transform.parent = gameObject.transform;
			rods[i].transform.Translate (new Vector3 (RodPosition(i), gameObject.transform.position.y, gameObject.transform.position.z));
			//rods[i].transform.GetComponent<Renderer> ().GetComponent<Material> ().color = Color.red;
		}

		gameObject.transform.rotation = origin_rotation;
	}

	void Update () {
		spectrumDecomposition = fft.makeFft (numberOfDecomposition, numberOfFrequencies);
		for (int i = 0; i < numberOfDecomposition; i++){
			    float spectrumValue = spectrumDecomposition [i]*4+0.1f;
			if (spectrumValue > 12f) {
				spectrumValue = 12f;
			}
			rods [i].transform.localScale = new Vector3 (1, spectrumValue, 1);
			rods [i].transform.localPosition = new Vector3 (
				rods [i].transform.localPosition.x,
				spectrumValue/2,
				rods [i].transform.localPosition.z
			);
		}
	}

	private void CheckNumberOfDecomposition () {
		if 		(numberOfDecomposition < 2)		{ numberOfDecomposition =  4; }
		else if (numberOfDecomposition % 2 != 0){ numberOfDecomposition += 1; }
		else if (numberOfDecomposition > 32)	{ numberOfDecomposition = 32; }
	}

	private float RodPosition(int n) {
		if (n < numberOfDecomposition / 2) {
			return -1.0f * ((numberOfDecomposition / 2.0f - n * templateRod.transform.localScale.x) - templateRod.transform.localScale.x / 2.0f);
		} else {
			return ((n - numberOfDecomposition / 2.0f) * templateRod.transform.localScale.x) + templateRod.transform.localScale.x / 2.0f;
		}
	}
}
