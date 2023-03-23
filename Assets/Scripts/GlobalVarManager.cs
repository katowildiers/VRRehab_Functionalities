using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVarManager : MonoBehaviour
{
    public static int globalRunID;
    public static int globalUserID;
    public static int exerciseID;
    public static int tryID;

    public static float l_left_range;
    public static float l_right_range;
    public static float l_up_range;
    public static float l_front_range;

    public static float r_left_range;
    public static float r_right_range;
    public static float r_up_range;
    public static float r_front_range;

    // Start is called before the first frame update
    void Start()
    {
        globalRunID= 0;
        globalUserID= 0;
        exerciseID= 0;
        tryID= 0;
    }

    void Update()
    {
        Debug.Log("testtest");
        Debug.Log(globalUserID);
    }

    public void setRedApple()
    {
        exerciseID = 0;
        tryID = 0;
    }

    public void setGreenApple()
    {
        exerciseID = 0;
        tryID = 1;
    }

    public void setOrangeApple()
    {
        exerciseID = 0;
        tryID = 2;
    }
}
