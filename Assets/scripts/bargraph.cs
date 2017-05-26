using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bargraph : MonoBehaviour {
	public GameObject templateRod;
	public int numberOfFrequencies;
	public int numberOfDecomposition;

	private GameObject[] rods;
	private float[] spectrumDecomposition;

	// Use this for initialization
	void Start () {
		spectrumDecomposition = new float[numberOfDecomposition];
		rods = new GameObject[numberOfDecomposition];
		for (int i = 0; i < numberOfDecomposition; i++) {
			rods[i] = Instantiate (templateRod);
			rods [i].transform.parent = this.transform;
			rods [i].transform.position = new Vector3 (transform.position.x+i*templateRod.transform.localScale.x, transform.position.y+templateRod.transform.position.y+transform.localScale.y/2, transform.position.z);
			//rods[i].transform.GetComponent<Renderer> ().GetComponent<Material> ().color = Color.red;
		}
	}
	
	// Update is called once per frame
	void Update () {
		spectrumDecomposition = fft.makeFft (numberOfDecomposition, numberOfFrequencies);
		for (int i = 0; i < numberOfDecomposition; i++){
			float spectrumValue = spectrumDecomposition [i]*10+0.3f;
			rods [i].transform.localScale = new Vector3 (1, spectrumValue, 1);
			rods [i].transform.position = new Vector3 (rods [i].transform.position.x, spectrumValue/2 , rods [i].transform.position.z);
		}
	}
}
