using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    /* 
    Code to control elements in the UI and is attached onto the Canvas object
    */
    public GameObject panel; // allergies list screen

    // arrows on the UI to guide the user to swipe left and right
    public GameObject lArrow;
    public GameObject rArrow;

    // boolean to keep track of what screen should be shown (allergies list or camera view)
    private bool isShowing = false;

    void Start()
    {
        // On application start, the left and right arrows appear on the screen
        panel.SetActive(isShowing);
        lArrow.SetActive(!isShowing);
        rArrow.SetActive(!isShowing);
    }

    public void togglePanel()
    {
        // Called when the 'Toggle View' button is pressed, hides the arros and shows the allergies list panel
        isShowing = !isShowing;
        panel.SetActive(isShowing);
        lArrow.SetActive(!isShowing);
        rArrow.SetActive(!isShowing);
    }
}
