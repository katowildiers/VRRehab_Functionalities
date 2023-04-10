using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTrigger : MonoBehaviour
{
    public GameObject coffeecup;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CoffeeCup"))
        {
            coffeecup.GetComponent<AddFoam>().raiseFoam();
        }
    }
}
