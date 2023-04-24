using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShowing : MonoBehaviour
{
    /*
    Script that is attached to the prefab which is kept in the list "ArPrefabs" in PlaceTrackedImage.cs

    Contains methods to switch to the next and previous prefab
    */
    private int objIndex = 0; // keeps track of which prefab is currently showing

    List<GameObject> childObjects = new List<GameObject>();
    

    void Start()
    {
        // each individual prefab is a child of the GameObject that this script is attached to
        // a list of all children is made upon startup
        Transform[] allChildren = GetComponentsInChildren<Transform>(includeInactive: true);
        bool first = true;
        foreach (Transform child in allChildren)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                childObjects.Add(child.gameObject);
            }
        }
        childObjects[objIndex].SetActive(true);
    }
    
    public void nextObj()
    {
        // method that changes the showing prefab to the next child, this is called when the user swipes right
        childObjects[objIndex].SetActive(false);
        if (objIndex == childObjects.Count - 1)
        {
            objIndex = 0;
        }
        else
        {
            objIndex++;
        }
        childObjects[objIndex].SetActive(true);
    }

    public void prevObj()
    {
        // method that changes the showing prefab to the previous child, this is called when the user swipes left
        childObjects[objIndex].SetActive(false);
        if (objIndex == 0)
        {
            objIndex =  childObjects.Count - 1;
        }
        else
        {
            objIndex--;
        }
        childObjects[objIndex].SetActive(true);
    }
}
