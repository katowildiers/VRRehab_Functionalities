using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine.Networking;

public class manager : MonoBehaviour
{
    public string username;
    public TMP_InputField inputField;
    public GameObject LoginCanvas;
    public TMP_InputField firstName;
    public TMP_InputField lastName;
    string CreateUserURL = "http://localhost/thesis/insertUser.php";
    string getUserIDURL = "http://localhost/thesis/userData.php";

    public void login()
    {
        username = inputField.text;
        print(username);
    }

    public void register()
    {
        username = inputField.text; 
        string fName = firstName.text;
        string lName = lastName.text;
        CreateUser(username, fName, lName);
    }

    public void getUID()
    {
        StartCoroutine(getUserID());
    }

    public void CreateUser(string username, string firstName, string lastName)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("firstNamePost", firstName);
        form.AddField("lastNamePost", lastName);
        WWW www = new WWW(CreateUserURL, form);
    }

    public IEnumerator getUserID()
    {
        Debug.Log("Entered the getUserID function");
        string username = inputField.text;
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);


        UnityWebRequest www = UnityWebRequest.Post(getUserIDURL, form);

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
