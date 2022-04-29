using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System;
using System.Net;
using System.Drawing;
using IronPython.Hosting;
using Newtonsoft.Json;
using System.Linq;
//using UnityEditor.Build;
using UnityEditor;


[RequireComponent(typeof(ARFaceManager))]
public class FaceToggler : MonoBehaviour
{
    [SerializeField]
    private Button faceTrackingToggle;

    [SerializeField]
    private Button swapFacesToggle;

    public Button addFace;

    public Button initiateScreenshot;

    public Button getSlack;

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
        addFace.onClick.AddListener(LancerMainSend);
        getSlack.onClick.AddListener(downloadSlack);
        arFaceManager.facePrefab.GetComponent<MeshRenderer>().material = materials[0].Material;
        initFace();
    }

    void initFace()
    {
        ButtonsVisibility(false);
        Texture2D texture = ScreenCapture.CaptureScreenshotAsTexture();
        byte[] bytes = texture.EncodeToPNG();
        NativeGallery.SaveImageToGallery(bytes, "AlbumTest", "ImageToUploadFaceTo", null);
        ButtonsVisibility(true);
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

    void ButtonsVisibility(bool hide)
    {
        swapFacesToggle.gameObject.SetActive(hide);
        addFace.gameObject.SetActive(hide);
        initiateScreenshot.gameObject.SetActive(hide);
        faceTrackingToggle.gameObject.SetActive(hide);
    }

    IEnumerator Screenshot()
    {
        ButtonsVisibility(false);
        yield return new WaitForEndOfFrame();
        Texture2D texture = ScreenCapture.CaptureScreenshotAsTexture();
        byte[] bytes = texture.EncodeToPNG();
        NativeGallery.SaveImageToGallery(bytes, "AlbumTest", "TestImage" + DateTime.Now.ToString("t"), null);
        ButtonsVisibility(true);
        //Object.Destroy(texture);
    }

    void TakeScreenShot()
    {
        StartCoroutine(Screenshot());
    }

    void Send()
    {

        string path = Application.persistentDataPath + "/Exemple.txt";
        SendMessage("Exemple.txt");
        TextWriter tw = new StreamWriter(path, true);
        tw.WriteLine("The next line!");
        tw.Close();
    }

    void test()
    {
        //PickImage(20000000);
        Debug.Log(Application.persistentDataPath);
    }

    void pyt()
    {
        var engine = Python.CreateEngine();
        ICollection<string> searchPaths = engine.GetSearchPaths();

        //Path to the folder of greeter.py
        searchPaths.Add(Application.dataPath);
        //Path to the Python standard library
        searchPaths.Add(Application.dataPath + @"/Plugins/Lib/");
        searchPaths.Add(Application.dataPath + @"/Plugins/Lib/slack");
        searchPaths.Add(Application.dataPath + @"/Plugins/Lib/chardet");
        searchPaths.Add(Application.dataPath + @"/Plugins/Lib/requests");
        searchPaths.Add(Application.dataPath + @"/Plugins/Lib/certifi");
        searchPaths.Add(Application.dataPath + @"/Plugins/Lib/urllib3");
        engine.SetSearchPaths(searchPaths);
        //Texture2D texture = ScreenCapture.CaptureScreenshotAsTexture();
        //byte[] bytes = texture.EncodeToPNG();
        string filePath = Application.dataPath + @"/Pictures/Lea.png";
        string filePath2 = Application.dataPath + @"/Assets//Pictures/Lea.png";
        string filePath3 = Application.dataPath;
        string filePath4 = "/home/bbj/UNITY/PROJECTS/AR masks/Assets//Pictures/Lea.png";
        byte[] bytes;
        bytes = File.ReadAllBytes(filePath);
        dynamic py = engine.ExecuteFile(Application.dataPath + @"/Scripts/Greeter2.py");
        dynamic greeter = py.Greeter();
        //Debug.Log(greeter.greet("test envoie unity"));
        //Debug.Log(greeter.greet2("Check out my text file!", "test file", filePath, bytes));
    }
    /* partie slack c#*/

    // main method with logic

    void LancerMainSend()
    {
        StartCoroutine(MainSend());
    }
    IEnumerator MainSend()
    {
        NameValueCollection parameters = new NameValueCollection();

        // put your token here
        string channelId = "C03AR3EGX54";
        string filePathAndroid = Application.persistentDataPath;
        parameters["channels"] = channelId;
        string URI = "https://slack.com/api/files.upload";
        string token = "xoxb-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ";
        ButtonsVisibility(false);
        yield return new WaitForEndOfFrame();
        Texture2D texture = ScreenCapture.CaptureScreenshotAsTexture();
        ButtonsVisibility(true);
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(filePathAndroid + "/test2.png", bytes);
        using (WebClient wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            wc.Headers[HttpRequestHeader.Accept] = "application/json";
            wc.QueryString = parameters;
            byte[] responseBytes = wc.UploadFile(URI, filePathAndroid +"/test2.png");
            String responseString = Encoding.UTF8.GetString(responseBytes);
            Debug.Log(responseString);
        }
    }

    void downloadSlack()
    {
        NameValueCollection parameters = new NameValueCollection();

        string tokenSlackAuth = "Bearer xoxp-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ";
        string tokenSlackAuth2 = "xoxb-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ";
        string tokenuser = "xoxp-3395519405008-3365112776422-3447743329173-c3e949dd2a80eeb60006ca2910f98346";
        string channelId = "C03AR3EGX54";
        parameters["channels"] = channelId;
        string URI = "https://slack.com/api/files.list";
        string token = "xoxb-3395519405008-3365818003510-fAdY2xwMZNRAkebCtuWaQ5aZ";

        String LinkFinal = "";
        String IDfile = "";
        using (WebClient wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.Authorization] = "Bearer " + tokenSlackAuth2;
            wc.Headers[HttpRequestHeader.Accept] = "application/json";
            wc.QueryString = parameters;
            String responseBytesS = wc.DownloadString(URI);
            List<string> result = responseBytesS?.Split(new string[] {"id"}, StringSplitOptions.None).ToList();
            //List<string> result = responseBytesS?.Split("id", StringSplitOptions.None).ToList();
            List<string> resultsplit = result[result.Count - 1]?.Split(',').ToList();
            List<string> resultsplitID = resultsplit[0]?.Split('"').ToList();
            List<string> resultsplitLinkDebut = resultsplit[19]?.Split(new string[] {"/files.slack.com\\/"}, StringSplitOptions.None).ToList();
            //List<string> resultsplitLinkDebut = resultsplit[19]?.Split("/files.slack.com\\/", StringSplitOptions.None).ToList();
            List<string> resultsplitLinkMoyen = resultsplitLinkDebut[1]?.Split('\\').ToList();
            List<string> resultsplitLinkPug = resultsplit[46]?.Split('-').ToList();
            IDfile = resultsplitID[2];
            String IDTeamUser = resultsplitLinkMoyen[1];
            String NomFile = resultsplitLinkMoyen[3];
            String Pug = resultsplitLinkPug[3];

            String Link = "https://files.slack.com/files-pri" + IDTeamUser + NomFile + "?pub_secret=" + Pug;
            LinkFinal = Link.Replace("\"", "");
            Console.Write("\n");
        }

        URI = "https://slack.com/api/files.sharedPublicURL";
        parameters["file"] = IDfile;

        using (WebClient wc2 = new WebClient())
        {
            wc2.Headers[HttpRequestHeader.Authorization] = "Bearer " + tokenuser;
            wc2.Headers[HttpRequestHeader.Accept] = "application/json";
            wc2.QueryString = parameters;
            String responseBytesS = wc2.DownloadString(URI);
        }

        Console.Write(LinkFinal);

        Texture2D texture = new Texture2D(128, 128);

        using (WebClient webClient = new WebClient())
        {
            byte[] data = webClient.DownloadData(LinkFinal);
            texture.LoadRawTextureData(data);
        }


        materials[0].Material.SetTexture("testmat", texture);
        
        arFaceManager.facePrefab.GetComponent<MeshRenderer>().material = materials[0].Material;

    }

    private IEnumerator WaitForPost(WWW post)
    {
        yield return post;

        Debug.Log("Message sent.");
    }
}

[System.Serializable]
public class FaceMaterial
{
    public Material Material;

    public string Name;
}