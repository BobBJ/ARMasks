using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterials : MonoBehaviour
{

    public Material[] mats;
    public int number; 

    public int xe = 0;

    Renderer MatRend;

    bool change = false;

    Camera mainCamera;
    
    public Text xtext;

    // Start is called before the first frame update
    void Start()
    {
        number = 1;
        MatRend = GetComponent<Renderer>();
        MatRend.sharedMaterial = mats[number];
        xtext.GetComponent<UnityEngine.UI.Text>().text = "bim";
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
        xtext.text = xe.ToString();
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
        }*/
        change = true;
        xe++;
    }
}
