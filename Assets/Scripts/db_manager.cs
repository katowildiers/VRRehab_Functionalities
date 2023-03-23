using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class db_manager : MonoBehaviour
{
    public int runID;
    // Start is called before the first frame update
    void Start()
    {        
        uploadRunData();
    }

    public void uploadRunData()
    {
        WWWForm form = new WWWForm();
        form.AddField("runidPost", GlobalVarManager.globalRunID);
        form.AddField("useridPost", GlobalVarManager.globalUserID);
        form.AddField("controllerPost", "oculus");
        float startTime = DateTime.Now.Hour * 60 * 60 * 60 + DateTime.Now.Minute * 60 * 1000 + DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
        form.AddField("timestartPost", startTime.ToString());
        WWW www = new WWW("http://localhost/thesis/insertRun.php", form);
    }
}
