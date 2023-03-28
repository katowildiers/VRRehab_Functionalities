using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringMover : MonoBehaviour
{
    private IEnumerator Waiter()
    {
        for (int i = 0; i < 100; i++)
        {
            transform.localPosition += new Vector3(0, (float)0.008, 0);
            yield return new WaitForSeconds((float)0.005);
        }
        for (int i = 0; i < 100; i++)
        {
            transform.localPosition += new Vector3((float)0.008, 0, 0);
            yield return new WaitForSeconds((float)0.005);
        }
        for (int i = 0; i < 100; i++)
        {
            transform.localPosition += new Vector3(0, (float)-0.008, 0);
            yield return new WaitForSeconds((float)0.005);
        }
        for (int i = 0; i < 100; i++)
        {
            transform.localPosition += new Vector3((float)-0.008, 0, 0);
            yield return new WaitForSeconds((float)0.005);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Marker"))
        {
            StartCoroutine(Waiter());
        }
    }
}
