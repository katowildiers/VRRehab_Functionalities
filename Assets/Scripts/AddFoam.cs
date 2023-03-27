using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFoam : MonoBehaviour
{
    public bool isPooring;
    public GameObject foam;
    // Start is called before the first frame update
    void Start()
    {
        isPooring = false;
    }

    public void startPooring() { isPooring = true; }
    public void stopPooring() { isPooring = false; }


    // Update is called once per frame
    public void raiseFoam()
    {
        if (isPooring)
        {
            if (foam.transform.localPosition.y >= 0.14)
            {
                //Implement that it stops pooring   
            }
            foam.transform.localPosition += new Vector3(0, (float)0.001, 0 );
            
        }
    }
}
