using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;

public class manager : MonoBehaviour
{
    public string username;
    public TMP_InputField inputField;
    public GameObject LoginCanvas;
    public TMP_InputField firstName;
    public TMP_InputField lastName;
    string CreateUserURL = "http://localhost/thesis/insertUser.php";

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

    public void CreateUser(string username, string firstName, string lastName)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("firstNamePost", firstName);
        form.AddField("lastNamePost", lastName);
        print(form);
        WWW www = new WWW(CreateUserURL, form);
    }
}
