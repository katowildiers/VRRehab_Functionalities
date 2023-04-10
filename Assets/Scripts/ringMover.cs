using JetBrains.Annotations;
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

    private IEnumerator Square()
    {
        Vector3 startPos = transform.localPosition;
        Vector3 targetPos;
        float speed = 1f;
        bool finished= false;
        while (!finished)
        {
            transform.localPosition = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            // Hier dan een if statement die de target en startpos aanpast als ge aan een hoek bent. 
        }
        yield return new WaitForSeconds((float)0.005);       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Marker"))
        {
            StartCoroutine(Square());
        }
    }
}
