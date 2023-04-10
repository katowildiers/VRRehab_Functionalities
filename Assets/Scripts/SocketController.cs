using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketController : MonoBehaviour
{
    public XRSocketInteractor socket;
    public GameObject gamePlay;

    // Start is called before the first frame update
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }
    //Everytime something runs into the socket
    public void SocketCheck() 
    {
        IXRSelectInteractable item = socket.GetOldestInteractableSelected();

        if (item.transform.CompareTag("Apple"))
        {
            gamePlay.GetComponent<FillTray>().appleDone = true;
            Debug.Log("Apple is done");
        }
        else if (item.transform.CompareTag("CoffeeCup"))
        {
            gamePlay.GetComponent<FillTray>().coffeeDone = true;
            Debug.Log("Coffeecup is done");
        }
        else
        {
            UnityEngine.Debug.Log("This is not on the list");
        }
    }
}
