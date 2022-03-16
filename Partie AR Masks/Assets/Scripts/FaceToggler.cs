using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using System.Collections;
//using System.IO;
using System;

[RequireComponent(typeof(ARFaceManager))]
public class FaceToggler : MonoBehaviour
{
    [SerializeField]
    private Button faceTrackingToggle;

    [SerializeField]
    private Button swapFacesToggle;

    public Button initiateScreenshot;

    private ARFaceManager arFaceManager;

    public bool faceTrackingOn = true;

    private int swapCounter = 0;

    [SerializeField]
    public FaceMaterial[] materials;

    void Awake()
    {
        arFaceManager = GetComponent<ARFaceManager>();

        faceTrackingToggle.onClick.AddListener(ToggleTrackingFaces);
        swapFacesToggle.onClick.AddListener(SwapFaces);
        initiateScreenshot.onClick.AddListener(TakeScreenShot);
        arFaceManager.facePrefab.GetComponent<MeshRenderer>().material = materials[0].Material;
    }

    void SwapFaces()
    {
        arFaceManager.enabled = true;
        swapCounter = swapCounter == materials.Length - 1 ? 0 : swapCounter + 1;

        foreach (ARFace face in arFaceManager.trackables)
        {
            face.GetComponent<MeshRenderer>().material = materials[swapCounter].Material;
        }

        swapFacesToggle.GetComponentInChildren<Text>().text = $"Face Material ({materials[swapCounter].Name})";
    }

    void ToggleTrackingFaces()
    {
        faceTrackingOn = !faceTrackingOn;

        arFaceManager.enabled = faceTrackingOn;
        foreach (ARFace face in arFaceManager.trackables)
        {
            face.GetComponent<MeshRenderer>().enabled = faceTrackingOn;
            face.enabled = faceTrackingOn;
        }


        //faceTrackingToggle.GetComponentInChildren<Text>().text = $"Face Tracking {(arFaceManager.enabled ? "Off" : "On" )}";
    }

    IEnumerator Screenshot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = ScreenCapture.CaptureScreenshotAsTexture();
        byte[] bytes = texture.EncodeToPNG();
        NativeGallery.SaveImageToGallery(bytes, "AlbumTest", "TestImage" + DateTime.Now.ToString("t"), null);
        //Object.Destroy(texture);
    }

    void TakeScreenShot()
    {
        StartCoroutine(Screenshot());
    }
}

[System.Serializable]
public class FaceMaterial
{
    public Material Material;

    public string Name;
}