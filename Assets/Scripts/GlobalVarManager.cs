using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVarManager : MonoBehaviour
{
    public static int globalRunID;
    public static int globalUserID;
    public static int exerciseID;
    public static int tryID;

    // Start is called before the first frame update
    void Start()
    {
        globalRunID= 0;
        globalUserID= 0;
        exerciseID= 0;
        tryID= 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
