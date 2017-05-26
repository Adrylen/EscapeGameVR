﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fft : MonoBehaviour{
	public static float[] makeFft(int numberOfDecomposition, int numberOfFrequencies){
		float[] spectrumDecomposition;
		float[] spectrum = new float[numberOfFrequencies];
		spectrumDecomposition = new float[numberOfDecomposition];
		AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

		for (int i = 0; i < numberOfDecomposition; i++){
			spectrumDecomposition [i] = 0;
			for(int j = i*numberOfDecomposition+1; j < (i+1)*numberOfDecomposition-1; j++){
				spectrumDecomposition[i]+=spectrum[j];
			}
		}

		return spectrumDecomposition;
	}
}