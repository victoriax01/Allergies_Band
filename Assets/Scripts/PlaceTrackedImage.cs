using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceTrackedImage : MonoBehaviour
{
    /*
    Script that is attached to the AR Session Origin and used to place an AR object on the detected and tracked image that is predefined in the Reference Image Library

    Much of this code is similar to the tutorial code found here: https://gist.github.com/alastaira/92d790ed09330ea7a45e7c3a2a4d26e1
    */
    private ARTrackedImageManager _trackedImagesManager;
    public GameObject[] ArPrefabs; // the AR prefab to place

    private readonly Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();

    void Awake() {
        _trackedImagesManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable() {
        _trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable() {
        _trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs) {
        foreach (var trackedImage in eventArgs.added) {
            var imageName = trackedImage.referenceImage.name;

            foreach (var curPrefab in ArPrefabs) {
                if (string.Compare(curPrefab.name, imageName, System.StringComparison.OrdinalIgnoreCase) == 0
                    && !_instantiatedPrefabs.ContainsKey(imageName)) {
                    
                    var newPrefab = Instantiate(curPrefab, trackedImage.transform);
                    _instantiatedPrefabs[imageName] = newPrefab;
                }
            }
        }

        foreach (var trackedImage in eventArgs.updated) {
            _instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
        }

        foreach (var trackedImage in eventArgs.removed) {
            Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);

            _instantiatedPrefabs.Remove(trackedImage.referenceImage.name);
        }
    }

    public void UpdatePrefab(GameObject newObj)
    {
        ArPrefabs[0] = newObj;
    }
}
