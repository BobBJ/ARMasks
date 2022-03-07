/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ChangeMaterials : MonoBehaviour
{

    public Material[] mats;
    
    public int number; 
    public int xe = 0;

    Renderer MatRend;

    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        number = 1;
        MatRend = GetComponent<Renderer>();
        MatRend.sharedMaterial = mats[number];
    }

    // Update is called once per frame
    void Update()
    {
        if ((xe % 3) == 0)
        {
            number = 0;
        }
        if ((xe % 3) == 1)
        {
            number = 1;
        }
        if ((xe % 3) == 2)
        {
            number = 2;
        }
        MatRend.sharedMaterial = mats[number];
    }

    public void NextMaterial()
    {
        /*if (number < 2)
        {
            number++;
        }
        else
        {
            number = 0;
        }// a mettre avec / et *
        xe++;
    }
}
*/