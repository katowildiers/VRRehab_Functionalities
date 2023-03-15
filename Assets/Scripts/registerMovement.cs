using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class registerMovement : MonoBehaviour
{
    public int run_id;
    public int exercise_id;
    public int try_id;
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

    public void setExerciseID(int e_id, int t_id)
    {
        exercise_id = e_id;
        try_id = t_id;
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = DateTime.Now.Hour * 60 * 60 * 60 + DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
        filePath = Application.dataPath + "/CSV/QuestController_" + startTime + ".csv";
        writer = new StreamWriter(filePath);
        writer.WriteLine("time,r_id,r_xpos,r_ypos,r_zpos,r_speed,r_acceleration,l_xpos,l_ypos,l_zpos,l_speed,l_acceleration,");
        writer.Flush();
        lastposition_l = leftHand.transform.position;
        lastposition_r = rightHand.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Updating DB");
        DateTime dt = DateTime.Now;
        float time = dt.Hour * 60 * 60 * 60 + dt.Minute * 60 * 1000 + dt.Second * 1000 + dt.Millisecond - startTime;
        print(dt);
        print(startTime);
        int r_id = 0;

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

        writer.WriteLine(time + "," + r_id + "," + xPosR + "," + yPosR + "," + zPosR + "," + rSpeed + "," + rAcceleration + "," + xPosL + "," + yPosL + "," + zPosL + "," + lSpeed + "," + lAcceleration);
        writer.Flush();

        lastposition_l = leftHand.transform.position;
        lastposition_r = rightHand.transform.position;
    }

    
}
