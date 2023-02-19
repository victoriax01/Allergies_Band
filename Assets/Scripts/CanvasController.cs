using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject panel;
    public GameObject lArrow;
    public GameObject rArrow;
    private bool isShowing = false;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(isShowing);
        lArrow.SetActive(!isShowing);
        rArrow.SetActive(!isShowing);
    }

    public void togglePanel()
    {
        isShowing = !isShowing;
        panel.SetActive(isShowing);
        lArrow.SetActive(!isShowing);
        rArrow.SetActive(!isShowing);
    }
    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
