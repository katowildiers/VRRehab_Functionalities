using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class registerMovement : MonoBehaviour
{
    float xPosR;
    float yPosR;
    float zPosR;
    float rSpeed;
    float rAcceleration;
    float lastVelocity_r = 0;
    public Vector3 lastposition_r;

    float xPosL;
    float yPosL;
    float zPosL;
    float lSpeed;
    float lAcceleration;
    float lastVelocity_l = 0;
    public Vector3 lastposition_l;

    public GameObject rightHand;
    public GameObject leftHand;
    float startTime;
    static string filePath;
    StreamWriter writer;
    string dataBaseURL = "http://localhost/thesis/insertData.php";

    // Start is called before the first frame update
    void Start()
    {
        startTime = DateTime.Now.Hour * 60 * 60 * 60 + DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
        filePath = Application.dataPath + "/CSV/QuestController_" + GlobalVarManager.globalRunID + ".csv";
        writer = new StreamWriter(filePath);
        writer.WriteLine("time,r_id,r_xpos,r_ypos,r_zpos,r_speed,r_acceleration,l_xpos,l_ypos,l_zpos,l_speed,l_acceleration,");
        writer.Flush();
        lastposition_l = leftHand.transform.position;
        lastposition_r = rightHand.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        DateTime dt = DateTime.Now;
        float time = dt.Hour * 60 * 60 * 60 + dt.Minute * 60 * 1000 + dt.Second * 1000 + dt.Millisecond - startTime;

        int r_id = GlobalVarManager.globalRunID;
        int e_id = GlobalVarManager.exerciseID;
        int t_id = GlobalVarManager.tryID;

        xPosL = leftHand.transform.position.x;
        yPosL = leftHand.transform.position.y;
        zPosL = leftHand.transform.position.z;
        // lSpeed = leftHand.velocity.magnitude;
        lSpeed = (leftHand.transform.position - lastposition_l).magnitude / Time.deltaTime;

        lAcceleration = (lSpeed - lastVelocity_l) / Time.fixedDeltaTime;
        lastVelocity_l = lSpeed;

        xPosR = rightHand.transform.position.x;
        yPosR = rightHand.transform.position.y;
        zPosR = rightHand.transform.position.z;
        //rSpeed = rightHand.velocity.magnitude;
        rSpeed = (rightHand.transform.position - lastposition_r).magnitude / Time.deltaTime;

        lAcceleration = (rSpeed - lastVelocity_r) / Time.fixedDeltaTime;
        lastVelocity_r = rSpeed;

        writer.WriteLine(time + "," + r_id + "," + xPosR + "," + yPosR + "," + zPosR + "," + rSpeed + "," + rAcceleration + "," + xPosL + "," + yPosL + "," + zPosL + "," + lSpeed + "," + lAcceleration + "," + e_id + "," + t_id);
        writer.Flush();

        lastposition_l = leftHand.transform.position;
        lastposition_r = rightHand.transform.position;

        StartCoroutine(InsertData(time, xPosR, yPosR, zPosR, xPosL, yPosL, zPosL, rSpeed, rAcceleration, lSpeed, lAcceleration));
    }
    
    public IEnumerator InsertData(float t, float xPosR, float yPosR, float zPosR, float xPosL, float yPosL, float zPosL, float rSpeed, float rAcc, float lSpeed, float lAcc)
    {
        WWWForm form = new WWWForm();
        form.AddField("time", t.ToString());
        form.AddField("runID", GlobalVarManager.globalRunID);
        form.AddField("xPositionR", xPosR.ToString());
        form.AddField("yPositionR", yPosR.ToString());
        form.AddField("zPositionR", zPosR.ToString());
        form.AddField("rSpeed", rSpeed.ToString());
        form.AddField("rAcc", rAcc.ToString());

        form.AddField("xPositionL", xPosL.ToString());
        form.AddField("yPositionL", yPosL.ToString());
        form.AddField("zPositionL", zPosL.ToString());
        form.AddField("lSpeed", lSpeed.ToString());
        form.AddField("lAcc", lAcc.ToString());

        form.AddField("exerciseID", GlobalVarManager.exerciseID);
        form.AddField("tryID", GlobalVarManager.tryID);
        UnityWebRequest www = UnityWebRequest.Post(dataBaseURL, form);

        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            Debug.Log(form.data);
        }
        else
        {
            Debug.Log("Post request complete!" + " Response Code: " + www.responseCode);
            string responseText = www.downloadHandler.text;
            Debug.Log("Response Text:" + responseText);
        }
    }   
}
