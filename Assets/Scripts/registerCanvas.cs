using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class registerCanvas : MonoBehaviour
{
    public GameObject firstName;
    public GameObject lastName;
    public GameObject registerButton2;
    public GameObject loginButton;
    public GameObject registerButton1;

    public void registerScreen()
    {
        firstName.SetActive(true);
        lastName.SetActive(true);
        registerButton2.SetActive(true);
        loginButton.SetActive(false);
        registerButton1.SetActive(false);
    }
}
