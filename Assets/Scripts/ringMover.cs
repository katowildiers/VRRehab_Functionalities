using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringMover : MonoBehaviour
{
    public int level = 1;

    private IEnumerator Square()
    {
        for (int i = 0; i < 100; i++)
        {
            transform.localPosition += new Vector3(0, (float)0.008, 0);
            yield return new WaitForSeconds((float)0.005);
        }
        GameObject.Find("Ring").GetComponent<Renderer>().material.color = new Color(250, 0, 0, 100f);
        for (int i = 0; i < 100; i++)
        {
            transform.localPosition += new Vector3((float)0.008, 0, 0);
            yield return new WaitForSeconds((float)0.005);
        }
        GameObject.Find("Ring").GetComponent<Renderer>().material.color = new Color(0, 250, 0, 100f);
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

        level = 2;
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 10; i++)
        {
            transform.localPosition += new Vector3((float)0.020, (float)0.010, 0);
            yield return new WaitForSeconds((float)0.001);
        }

    }


    private IEnumerator House()
    {
        GameObject.Find("Ring").GetComponent<Renderer>().material.color = new Color(250, 0, 0, 60);

        for (int i = 0; i < 50; i++)
        {
            transform.localPosition += new Vector3(0, (float)0.008, 0);
            yield return new WaitForSeconds((float)0.005);
        }
        for (int i = 0; i < 50; i++)
        {
            transform.localPosition += new Vector3((float)0.008, 0, 0);
            yield return new WaitForSeconds((float)0.005);
        }
        for (int i = 0; i < 50; i++)
        {
            transform.localPosition += new Vector3(0, (float)-0.008, 0);
            yield return new WaitForSeconds((float)0.005);
        }
        for (int i = 0; i < 50; i++)
        {
            transform.localPosition += new Vector3((float)-0.008, 0, 0);
            yield return new WaitForSeconds((float)0.005);
        }
        for (int i = 0; i < 50; i++)
        {
            transform.localPosition += new Vector3(0, (float)0.008, 0);
            yield return new WaitForSeconds((float)0.005);
        }
        for (int i = 0; i < 25; i++)
        {
            transform.localPosition += new Vector3((float)0.01, (float)0.008, 0);
            yield return new WaitForSeconds((float)0.005);
        }
        for (int i = 0; i < 25; i++)
        {
            transform.localPosition += new Vector3((float)0.01, (float)-0.008, 0);
            yield return new WaitForSeconds((float)0.005);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Marker"))
        {
            if (level == 1)
            {
                StartCoroutine(Square());
            }
            if (level == 2)
            {
                StartCoroutine(House());
            }
        }
    }

    private IEnumerator moveLeft(int amount, float speed) 
    {
        for (int i = 0; i < amount; i++)
        {
            transform.localPosition += new Vector3((float)-0.008, 0, 0);
            yield return new WaitForSeconds((float)speed);
        }
    }
    private IEnumerator moveUp(int amount, float speed)
    {
        for (int i = 0; i < amount; i++)
        {
            transform.localPosition += new Vector3(0, (float)0.008, 0);
            yield return new WaitForSeconds((float)speed);
        }
    }
    private IEnumerator moveRight(int amount, float speed)
    {
        for (int i = 0; i < amount; i++)
        {
            transform.localPosition += new Vector3((float)0.008, 0, 0);
            yield return new WaitForSeconds((float)speed);
        }
    }
    private IEnumerator moveDown(int amount, float speed)
    {
        for (int i = 0; i < amount; i++)
        {
            transform.localPosition += new Vector3(0, (float)-0.008, 0);
            yield return new WaitForSeconds((float)speed);
        }
    }
}
