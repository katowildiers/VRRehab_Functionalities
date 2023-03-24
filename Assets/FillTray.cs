using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillTray : MonoBehaviour
{
    private bool coffeeDone;
    public bool appleDone;
    public GameObject level1Done;

    public void CoffeeDone() { coffeeDone = true; }
    public void AppleDone() { appleDone = true; }

    // Start is called before the first frame update
    void Start()
    {
        level1Done.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (coffeeDone && appleDone) 
        {
            level1Done.SetActive(true);
        }
    }
}
