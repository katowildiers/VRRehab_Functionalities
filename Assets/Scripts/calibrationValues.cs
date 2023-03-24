using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class calibrationValues : MonoBehaviour
{
    public GameObject XROrigin;
    bool ignorefirstl = false;
    bool ignorefirstr = false;
    public GameObject bowl;
    public GameObject leftApple;
    public GameObject rightApple;

    public Collider rightHand;
    public Collider leftHand;

    public GameObject r_front;
    public GameObject r_left;
    public GameObject r_right;
    public GameObject r_up;

    public GameObject l_front;
    public GameObject l_left;
    public GameObject l_right;
    public GameObject l_up;

    float r_leftStart;
    float r_rightStart;
    float r_upStart;
    float r_frontStart;

    float l_leftStart;
    float l_rightStart;
    float l_upStart;
    float l_frontStart;

    // Start is called before the first frame update
    void Start()
    {
        r_leftStart = r_left.transform.position.x;
        r_rightStart = r_right.transform.position.x;
        r_upStart = r_up.transform.position.y;
        r_frontStart = r_front.transform.position.z;

        l_leftStart = l_left.transform.position.x;
        l_rightStart = l_right.transform.position.x;
        l_upStart = l_up.transform.position.y;
        l_frontStart = l_front.transform.position.z;

        XROrigin.transform.position = new Vector3(2.454f, 0.01f, -4.139f);
    }

    public void storeCalibrationValuesLeft()
    {
        if (ignorefirstl)
        {
            GlobalVarManager.l_left_range = l_left.transform.position.x - l_leftStart;
            GlobalVarManager.l_front_range = l_frontStart - l_front.transform.position.z;
            GlobalVarManager.l_right_range = l_rightStart - l_right.transform.position.x;
            GlobalVarManager.l_up_range = l_up.transform.position.y - l_upStart;

            XROrigin.transform.position = new Vector3(-0.47f, 0.01f, -4.139f);
        }
        else
        {
            ignorefirstl = true;
        }
    }


    public void storeCalibrationValuesRight()
    {
        if (ignorefirstr)
        {
            GlobalVarManager.r_left_range = r_left.transform.position.x - r_leftStart;
            GlobalVarManager.r_front_range = r_frontStart - r_front.transform.position.z;
            GlobalVarManager.r_right_range = r_rightStart - r_right.transform.position.x;
            GlobalVarManager.r_up_range = r_up.transform.position.y - r_upStart;
            rightHand.isTrigger= true;
            leftHand.isTrigger= true;
            leftApple.transform.Translate(GlobalVarManager.l_left_range, 0, 0);
            rightApple.transform.Translate(-GlobalVarManager.l_right_range, 0, 0);
            bowl.transform.Translate(0, 0, -GlobalVarManager.l_up_range);

            XROrigin.transform.position = new Vector3(-3.65f, 0.01f, -4.139f);
            uploadRunData();
        }
        else
        {
            ignorefirstr = true;
        }
    }
    public void uploadRunData()
    {
        WWWForm form = new WWWForm();
        form.AddField("runidPost", GlobalVarManager.globalRunID);
        form.AddField("useridPost", GlobalVarManager.globalUserID);
        form.AddField("controllerPost", "oculus");
        form.AddField("lRangeLeft", GlobalVarManager.l_left_range.ToString());
        form.AddField("lRangeRight", GlobalVarManager.l_right_range.ToString());
        form.AddField("lRangeFront", GlobalVarManager.l_front_range.ToString());
        form.AddField("lRangeUp", GlobalVarManager.l_up_range.ToString());
        form.AddField("rRangeLeft", GlobalVarManager.r_left_range.ToString());
        form.AddField("rRangeRight", GlobalVarManager.r_right_range.ToString());
        form.AddField("rRangeFront", GlobalVarManager.r_front_range.ToString());
        form.AddField("rRangeUp", GlobalVarManager.r_up_range.ToString());

        WWW www = new WWW("http://localhost/thesis/insertRun.php", form);
    }

    public void setRedApple()
    {
        GlobalVarManager.exerciseID = 0;
        GlobalVarManager.tryID = 5;
    }

    public void setGreenApple()
    {
        GlobalVarManager.exerciseID = 0;
        GlobalVarManager.tryID = 6;
    }

    public void setOrangeApple()
    {
        GlobalVarManager.exerciseID = 0;
        GlobalVarManager.tryID = 7;
    }

    public void setRedAppleRight()
    {
        GlobalVarManager.exerciseID = 0;
        GlobalVarManager.tryID = 8;
    }
}
