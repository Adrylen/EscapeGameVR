using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fft : MonoBehaviour{
	public static float[] makeFft(int numberOfDecomposition, int numberOfFrequencies){
		float[] spectrumDecomposition;
		float[] spectrum = new float[numberOfFrequencies];
		spectrumDecomposition = new float[numberOfDecomposition];
        float Facteur;
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

		for (int i = 0; i < numberOfDecomposition; i++){
			spectrumDecomposition [i] = 0;
			for(int j = i*(numberOfFrequencies/numberOfDecomposition)+1; j < (i+1)*(numberOfFrequencies / numberOfDecomposition)- 1; j++){
				spectrumDecomposition[i]+=spectrum[j];
			}
            
		}
        float accel = 0.01f;
        float speed = -0.02f;
        float pos = 0.5f;

        for (int i = 0; i < numberOfDecomposition; i++)
        {
            accel -= 0.00005f;
            speed += accel;
            pos += speed;
            spectrumDecomposition[i] *= pos;
        }

        return spectrumDecomposition;
	}
}