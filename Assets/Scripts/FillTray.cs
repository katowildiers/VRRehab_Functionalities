using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FillTray : MonoBehaviour
{

    public bool coffeeDone;
    public bool appleDone;
    public GameObject level1Done;

    public void elementInSocket(string tag) {
        if (tag == "Apple") 
        {
            appleDone = true;
        }
        else if (tag == "Coffee")
        {
            coffeeDone = true;
        }
        else 
        {
            //Debug.log("This is not on the list");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        level1Done.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (coffeeDone && appleDone) 
        {
            level1Done.SetActive(true);
        }
    }
}
