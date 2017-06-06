using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightBarScript : MonoBehaviour {


    public AudioSource sourceAudio;

    private Renderer[] lightBar;
    public Renderer[,] doubleLight;
    int n=0;
    float k=0, l=0, m=0;
    System.Random rnd5 = new System.Random();
    System.Random rnd = new System.Random();
    System.Random rnd2 = new System.Random();
    System.Random rnd3 = new System.Random();
    public int numberOfFrequencies;
    public int numberOfDecomposition;
    private float[] spectrumDecomposition;
    private int poo;


    void Start ()
    {
        doubleLight = new Renderer[32, 182];
        lightBar = GetComponentsInChildren<Renderer>();
        tabToPanel(lightBar, ref doubleLight);
        spectrumDecomposition = new float[numberOfDecomposition];
        //allumerColone(0, 25, doubleLight);
        foreach(Renderer element in doubleLight)
        {
            switchOffPixel(element);
        }

        //changePixelColor(doubleLight[0, 0], Color.white);

    }

    void Update()
    {
        //barGraph(doubleLight);
        effetRespirant(doubleLight);
    }

    void tabToPanel (Renderer[] tab, ref Renderer[,] doubleLight)
    {
        int i=0,j=0,k=0;
        int inc = 0;

        while (i < tab.Length)
        {
            if (k == 13)
            {
                j += 1;
                k = 0;
            }

            if (j == 32)
            {
                inc++;
                j=0;
                k = 0;
            }

            doubleLight[j, k+13*inc] = new Renderer();
            doubleLight[j, k+13*inc] = tab[i];
            k++;
            i++;
        }

    }

    void switchOffPixel(Renderer pixel)
    {
        pixel.material.EnableKeyword("_EMISSION");
        pixel.material.SetColor("_Color", Color.black);
        pixel.material.SetColor("_SpecColor", Color.black);
        pixel.material.SetColor("_Emission", Color.black);
    }

    void changePixelColor(Renderer pixel, Color color)
    {
        pixel.material.EnableKeyword("_EMISSION");
        pixel.material.SetColor("_Color", color);
        pixel.material.SetColor("_SpecColor", color);
        pixel.material.SetColor("_Emission", color);
    }

    void effetRandom (Renderer[,] aPanel)
    {
        float x= rnd.Next(0, 256), y= rnd.Next(0, 256), z= rnd.Next(0, 256);
        int count=0;
        foreach(Renderer element in aPanel)
        {
            if(count==1092)
            {
                x = rnd.Next(0, 256);
                y = rnd.Next(0, 256);
                z = rnd.Next(0, 256);
                count = 0;
            }
             
            changePixelColor(element,new Color(x/256,y/256,z/256));
            count++;
        }
    }

    void effetRespirant(Renderer[,] aPanel)
    {
        k += 10;
        l += 10;
        m += 10;
        foreach (Renderer element in aPanel)
        {
            changePixelColor(element, new Color((k % 256)/256, 1-(l % 256)/256, 1-(m % 256)/256));
        }

    }

    void effetOnOff(Renderer[,] aPanel)
    {
        if (n == 5)
        {
            int test;
            foreach (Renderer element in aPanel)
            {
                changePixelColor(element, Color.cyan);
            }
            foreach (Renderer element in aPanel)
            {
                test = rnd5.Next(0, 15);
                if (test != 0)
                {
                    switchOffPixel(element);
                }
            }
            n = 0;
        }
        n++;

    }

    void allumerColonne(int colonne, int valeur, Renderer[,] aPanel)
    {
        int i,j;
        j = colonne;
        float test;
        for (i = 31; i >= 31 - valeur; i--)
        {
            test = 31 - i;
            float valeurR = 1 - test /22;
            if(test >20) { valeurR = 0.5F + (float)test/150; }
            float valeurV = test / 22;
            changePixelColor(aPanel[i, j], new Color(valeurR,valeurV, 1));
        }
    }

    void pixelFall(Renderer[,] aPanel)
    {
        int i=0, j=0;
        Color tempColor;
        while(i<aPanel.GetLength(1))
        {
            j = 0;
            while (j<aPanel.GetLength(0)-1)
            {
                if (aPanel[j, i].material.color != Color.black)
                {
                   tempColor = aPanel[j, i].material.GetColor("_Color");
                   switchOffPixel(aPanel[j, i]);
                   changePixelColor(aPanel[j + 1, i], tempColor);
                   if (i < 181) { i++; j = 0; }
                   else {j = 31; }
                }

                else { j++; }
            }
            i++;
        }
    }

    void barGraph(Renderer[,] aPanel)
    {
        spectrumDecomposition = fft.makeFft(numberOfDecomposition, numberOfFrequencies);
        pixelFall(aPanel);
        for (int i = 0; i < numberOfDecomposition; i++)
        {
            float spectrumValue = spectrumDecomposition[i] * 100;
            if (spectrumValue > 31f)
            {
                //Debug.Log("ON DEPASSE LA VALEUR CAPITAIIIIIIIIIINNE");
                spectrumValue = 31f;
            }
            int width = 182 / numberOfDecomposition;
            int valeur = i + i * (width-1);
            for(int j = valeur; j<valeur+width;j++)
            {
                allumerColonne(j, (int)spectrumValue, doubleLight);
            }
            
        }
    }
}
