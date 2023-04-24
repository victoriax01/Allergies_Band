using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    /*
    Legacy script used to switch between showing different allergies
    */
    public static bool swipeDetected = false;
    public static int swipeDir = 0;
    
    [SerializeField]
    private Touch touch;

    private Vector2 beginTouchPos, endTouchPos;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            SwipeDetector.swipeDetected = false;

            if (touch.phase == TouchPhase.Began)
            {
                beginTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPos = touch.position;

                if (beginTouchPos.x > endTouchPos.x)
                {
                    SwipeDetector.swipeDetected = true;
                    SwipeDetector.swipeDir = 1; // RIGHT
                }
                else if (beginTouchPos.x < endTouchPos.x)
                {
                    SwipeDetector.swipeDetected = true;
                    SwipeDetector.swipeDir = 2; // LEFT
                }
            }
        }
    }
}
