using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class faceof : MonoBehaviour
{
    // Start is called before the first frame update

    public ARSession session; 

    public bool faceTrackingOn = true;

   // public ARFaceManager arFaceManager;

    [SerializeField]
    private Button faceTrackingToggle;
    void Awake()
    {
        //arFaceManager = GetComponent<ARFaceManager>();
        faceTrackingToggle.onClick.AddListener(ToggleTrackingFaces);
    }

    void ToggleTrackingFaces()
    {
        faceTrackingOn = !faceTrackingOn;

        /*foreach(ARFace face in arFaceManager.trackables)
        {
            face.enabled = faceTrackingOn;
        }*/

        //session.enabled = faceTrackingOn;
       /* if (!faceTrackingOn)
        {
            arFaceManager.enabled = 
        }*/

        //arFaceManager.enabled = faceTrackingOn;

       // faceTrackingToggle.GetComponentInChildren<Text>().text = $"Face Tracking {(arFaceManager.enabled ? "Off" : "On")}";
    }
}
