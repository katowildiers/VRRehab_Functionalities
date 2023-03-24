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
        GameObject item = socket.selectTarget.gameObject;
        if (item.CompareTag("Apple"))
        {
            gamePlay.GetComponent<FillTray>().appleDone = true;
        }
    }
}
