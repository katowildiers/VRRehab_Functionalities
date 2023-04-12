using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Threading;
using UnityEngine;

public class ringMover : MonoBehaviour
{
    public int level = 1;
    float timeCounter = 0;
    float speed;
    float width;
    float height;
    public GameObject squarecanvas;
    public GameObject housecanvas;
    public GameObject smileycanvas;

    public GameObject startSection;
    public GameObject toHouseSection;
    public GameObject toSmileySection;
    public GameObject endSection;

    void Start()
    {
        speed = 1;
        width = 1;
        height = 1;
    }

    private IEnumerator Square()
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

        GameObject.Find("Ring").SetActive(false);
        level = 2;
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 10; i++)
        {
            transform.localPosition += new Vector3((float)0.020, (float)0.010, 0);
            yield return new WaitForSeconds((float)0.001);
        }

        GameObject.Find("Ring").SetActive(true);
        GameObject.Find("Ring").GetComponent<Renderer>().material.color = new Color(250, 0, 0, 0.3f);
        
        squarecanvas.transform.localPosition = new Vector3(-6.5f,2.1f,3.7f);

        housecanvas.SetActive(true);
        toHouseSection.SetActive(true);
    }


    private IEnumerator House1()
    {
        toHouseSection.SetActive(false);
        for (int i = 0; i < 50; i++)
        {
            transform.localPosition += new Vector3(0, (float)0.008, 0);
            yield return new WaitForSeconds((float)0.001);
        }
        for (int i = 0; i < 50; i++)
        {
            transform.localPosition += new Vector3((float)0.008, 0, 0);
            yield return new WaitForSeconds((float)0.001);
        }
        for (int i = 0; i < 50; i++)
        {
            transform.localPosition += new Vector3(0, (float)-0.008, 0);
            yield return new WaitForSeconds((float)0.001);
        }
        for (int i = 0; i < 50; i++)
        {
            transform.localPosition += new Vector3((float)-0.008, 0, 0);
            yield return new WaitForSeconds((float)0.001);
        }

        GameObject.Find("Ring").SetActive(false);

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 50; i++)
        {
            transform.localPosition += new Vector3(0, (float)0.008, 0);
            yield return new WaitForSeconds((float)0.005);
        }

        GameObject.Find("Ring").GetComponent<Renderer>().material.color = new Color(0, 0, 250, 0.3f);
        GameObject.Find("Ring").SetActive(true);
        level = 3;
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator House2()
    { 
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

        GameObject.Find("Ring").SetActive(false);
        level = 4;

        yield return new WaitForSeconds(1f);
        toSmileySection.SetActive(true);

        for (int i = 0; i < 35; i++)
        {
            transform.localPosition += new Vector3((float)-0.015, (float)-0.008, 0);
            yield return new WaitForSeconds((float)0.005);
        }
        GameObject.Find("Ring").GetComponent<Renderer>().material.color = new Color(210, 210, 3, 0.3f);
        GameObject.Find("Ring").SetActive(true);
    }

    private IEnumerator Smiley()
    {
        toSmileySection.SetActive(false);

        for (int i = 0; i < 63; i++)
        {
            timeCounter += 1;

            float x = Mathf.Cos(timeCounter*0.1f) * width * 0.03f;
            float y = Mathf.Sin(timeCounter*0.1f) * height * 0.03f; ;

            transform.localPosition += new Vector3(x, y, 0);
            yield return new WaitForSeconds((float)0.07/speed);
        }

        GameObject.Find("Ring").SetActive(false);
        endSection.SetActive(true);

        yield return new WaitForSeconds((float)4);
        endSection.SetActive(false);

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
                StartCoroutine(House1());
            }
            if (level == 3)
            {
                StartCoroutine(House2());
            }
            if (level == 4)
            {
                StartCoroutine(Smiley());
            }
        }
    }
}
