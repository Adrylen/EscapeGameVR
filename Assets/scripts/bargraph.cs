using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bargraph : MonoBehaviour {
	public GameObject templateRod;
	public int numberOfFrequencies;
	public int numberOfDecomposition;

	private GameObject cube;

	private GameObject[] rods;
	private float[] spectrumDecomposition;
	private int numberOfFreqByDecomposition;

	// Use this for initialization
	void Start () {
		numberOfFreqByDecomposition = numberOfFrequencies / numberOfDecomposition;
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
		float[] spectrum = new float[numberOfFrequencies];
		AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
		for (int i = 0; i < numberOfDecomposition; i++){
			spectrumDecomposition [i] = 0;
			for(int j = i*numberOfDecomposition+1; j < (i+1)*numberOfDecomposition-1; j++){
				spectrumDecomposition[i]+=spectrum[j];
			}
		}

		for (int i = 0; i < spectrumDecomposition.Length; i++) {
			float spectrumValue = spectrumDecomposition [i]*10+0.3f;
			rods [i].transform.localScale = new Vector3 (1, spectrumValue, 1);
			rods [i].transform.position = new Vector3 (rods [i].transform.position.x, spectrumValue/2 , rods [i].transform.position.z);
		}
	}
}
