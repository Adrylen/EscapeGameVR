﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmTable : MonoBehaviour {

    private CustomArrayList test = new CustomArrayList();
    public GameObject templateCube;
    private Vector3 origin = new Vector3();

    // Use this for initialization
    void Start() {
        origin = transform.localPosition;
        InitRythmBox(test);
        addRows(test);
        addLine(test);
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButton(0))
        {
            addLine(test);
        }

        if (Input.GetMouseButton(1))
        {
            removeLine(test);
        }
    }

    void InitRythmBox(CustomArrayList aRythmBox)
    {
        GameObject temp = new GameObject();
        Vector3 tempPosition;

        float xPos, yPos;

        List<GameObject> newList1 = new List<GameObject>();
        List<GameObject> newList2 = new List<GameObject>();
        List<GameObject> newList3 = new List<GameObject>();

        // Set the default model configuration

        aRythmBox.nbElementPerLine = 4;
        aRythmBox.nbLine = 3;

        // Horizontal line creation

        aRythmBox.Add(newList1);
        aRythmBox.Add(newList2);
        aRythmBox.Add(newList3);

        yPos = 0;
        xPos = 0;

        // Cube filling

        foreach (List<GameObject> element in aRythmBox)
        {
            for (int i = 0; i < aRythmBox.nbElementPerLine; i++)
            {
                tempPosition = new Vector3(xPos + (1.1f * i), yPos, 0);
                element.Add((GameObject)Instantiate(templateCube, tempPosition, Quaternion.identity, temp.transform));
            }
            yPos -= (1.1F);
            xPos = gameObject.transform.localPosition.x;
        }

        // Rotation adaptation

        temp.transform.localScale = transform.localScale;
        temp.transform.rotation = transform.rotation;
        temp.transform.localPosition = transform.position;
        temp.transform.parent = transform;

        // Moving children to root of the gameobject

        for (int i = temp.transform.childCount - 1; i >= 0; --i)
        {
            Transform child = temp.transform.GetChild(i);
            child.transform.parent = gameObject.transform;
        }

        // Removing Object for Rotation

        Destroy(temp);

    }


    void addRows (CustomArrayList aRythmBox)
    {
        float xPos, yPos;
        GameObject temp = new GameObject();
        yPos = 0;

        // Updating aRythmBox columnn number
      
        xPos = (1.1F) * aRythmBox.nbElementPerLine;
        aRythmBox.nbElementPerLine++;

        // Cube filling

        foreach (List<GameObject> element in aRythmBox)
        {
            Vector3 tempPosition = new Vector3(xPos, yPos, 0.0f);
            element.Add((GameObject)Instantiate(templateCube, tempPosition, Quaternion.identity, temp.transform));
            yPos -= (1.1F);
        }

        // Rotation adaptation

        temp.transform.localScale = transform.localScale;
        temp.transform.rotation = transform.rotation;
        temp.transform.localPosition = transform.position;
        temp.transform.parent = transform;
        

        // Moving children to root of the gameobject

        for (int i = temp.transform.childCount - 1; i >= 0; --i)
        {
            Transform child = temp.transform.GetChild(i);
            child.transform.parent = gameObject.transform;
        }

        // Removing Object for Rotation

        Destroy(temp);

    }

    void addLine(CustomArrayList aRythmBox)
    {
        List<GameObject> newList = new List<GameObject>();
        GameObject temp = new GameObject();
        Vector3 tempPosition;
        float yPos, xPos;
        yPos = (-1.1F) * aRythmBox.nbLine;
        xPos = 0;

        aRythmBox.Add(newList);
        aRythmBox.nbLine++;

        for(int i=0; i<aRythmBox.nbElementPerLine;i++)
        {
            tempPosition = new Vector3(xPos + (1.1f * i), yPos, 0);
            newList.Add((GameObject)Instantiate(templateCube, tempPosition, Quaternion.identity, temp.transform));
        }

        // Rotation adaptation

        temp.transform.localScale = transform.localScale;
        temp.transform.rotation = transform.rotation;
        temp.transform.localPosition = transform.position;
        temp.transform.parent = transform;


        // Moving children to root of the gameobject

        for (int i = temp.transform.childCount - 1; i >= 0; --i)
        {
            Transform child = temp.transform.GetChild(i);
            child.transform.parent = gameObject.transform;
        }

        // Removing Object for Rotation

        Destroy(temp);
    }

    void removeRow(CustomArrayList aRythmBox)
    {
        GameObject temp;

        // removing last cube for each horizontal line
        if(aRythmBox.nbElementPerLine > 1)
        {
            foreach (List<GameObject> aList in aRythmBox)
            {
                temp = aList[aList.Count - 1];
                aList.RemoveAt(aList.Count - 1);
                Destroy(temp);
            }
            // updating rows numbers
            aRythmBox.nbElementPerLine--;
        }

    }

    void removeLine(CustomArrayList aRythmBox)
    {
        if(aRythmBox.nbLine>1)
        {
            List<GameObject> tempList = (List<GameObject>)aRythmBox[aRythmBox.nbLine-1];

            foreach (GameObject element in tempList)
            {
                Destroy(element);
            }
            tempList.Clear();
            aRythmBox.RemoveAt(aRythmBox.nbLine - 1);
            aRythmBox.nbLine--;
        }
    }
}
