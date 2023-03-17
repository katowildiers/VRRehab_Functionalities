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
        // Get highest runID and add 1, to create new runID
        StartCoroutine(GetRequest("http://localhost/thesis/runData.php"));
        
        // At this point zou ge eigenlijk uw userid al nodig hebben, is nu gehardcode. 
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

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    GlobalVarManager.globalRunID = int.Parse(webRequest.downloadHandler.text) + 1;
                    break;
            }
        }
    }
}
