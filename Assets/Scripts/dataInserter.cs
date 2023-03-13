using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static System.Net.WebRequestMethods;

public class dataInserter : MonoBehaviour
{
    public string inputUserName;
    public string inputFirstName;
    public string inputLastName;
    
    string CreateUserURL = "http://localhost/thesis/insertUser.php";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            print(inputUserName);
            print(inputFirstName);
            print(inputLastName);   
            CreateUser(inputUserName, inputFirstName, inputLastName);
        }
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
