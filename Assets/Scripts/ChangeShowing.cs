using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShowing : MonoBehaviour
{
    public float timer, interval = 2f;
    private int objIndex = 0;
    // private bool temp = false;

    List<GameObject> childObjects = new List<GameObject>();
    private void Awake()
    {
        // SwipeDetectorA.OnSwipe += SwipeDetector_OnSwipe;
    }
    
    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log(allChildren.Length);
        Debug.Log(childObjects.Count);
        childObjects[objIndex].SetActive(true);
    }
    
    public void nextObj()
    {
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
    // Update is called once per frame
    void Update()
    {
        // childObjects[0].SetActive(false);
        // if (SwipeDetector.swipeDetected)
        // {
        //     childObjects[objIndex].SetActive(false);
        //     if (SwipeDetector.swipeDir == 2) // SWIPE LEFT
        //     {
        //         if (objIndex == 1)
        //         {
        //             objIndex = childObjects.Count - 1;
        //         }
        //         else
        //         {
        //             objIndex--;
        //         }
        //     }
        //     else if (SwipeDetector.swipeDir == 1) // SWIPE RIGHT
        //     {
        //         if (objIndex == childObjects.Count - 1)
        //         {
        //             objIndex = 1;
        //         }
        //         else
        //         {
        //             objIndex++;
        //         }
        //     }
        //     childObjects[objIndex].SetActive(true);
        //     SwipeDetector.swipeDetected = false;
        // }
        // Debug.Log(Time.deltaTime);
        // timer += Time.deltaTime;
        // if (timer >= interval)
        // {
        //     childObjects[objIndex].SetActive(false);
        //     if (objIndex == childObjects.Count - 1)
        //     {
        //         objIndex = 0;
        //     }
        //     else
        //     {
        //         objIndex++;
        //     }
        //     childObjects[objIndex].SetActive(true);
        //     timer = 0;
        // }   
    }
    
    // private void SwipeDetector_OnSwipe(SwipeData data)
    // {
    //     Debug.Log("Swipe in Direction: " + data.Direction);
    //     childObjects[objIndex].SetActive(false);
    //     if (data.Direction == SwipeDirection.Left)
    //     {
    //         if (objIndex == 0)
    //         {
    //             objIndex = childObjects.Count - 1;
    //         }
    //         else
    //         {
    //             objIndex--;
    //         }
    //     }
    //     else // SWIPE RIGHT
    //     {
    //         if (objIndex == childObjects.Count - 1)
    //         {
    //             objIndex = 0;
    //         }
    //         else
    //         {
    //             objIndex++;
    //         }
    //     }
    //     childObjects[objIndex].SetActive(true);
    // }
}
