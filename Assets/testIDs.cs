using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testIDs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GlobalVarManager.globalRunID);
        Debug.Log(GlobalVarManager.globalUserID);
    }
}
