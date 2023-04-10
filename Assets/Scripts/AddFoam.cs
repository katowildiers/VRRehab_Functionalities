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

    public void startedPooring() { isPooring = true; }
    public void stoppedPooring() { isPooring = false; }


    // Update is called once per frame
    public void raiseFoam()
    {
        if(isPooring)
        {
            Debug.Log("Filling cup");
            if (foam.transform.localPosition.y >= 0.14)
            {
                isPooring = false;
                Debug.Log("Cup is full");
            }
            foam.transform.localPosition += new Vector3(0, (float)0.0001, 0 );
            foam.transform.localScale += new Vector3((float)0.00008,0, (float)0.00008);

        }
    }
}
