using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PourWater : MonoBehaviour
{
    public ParticleSystem waterSpawner;
    public Transform kettleState;
    private bool waterPoured;

    // Start is called before the first frame update
    void Start()
    {
        waterSpawner.Stop();
        waterPoured = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (kettleState.localRotation.x > 0.7 && !waterPoured)
        { 
            Debug.Log("Pouring water");
            waterSpawner.Play();
            waterPoured = true;
        }
        else if (kettleState.localRotation.x <= 0.7 && waterPoured)
        {
            Debug.Log(kettleState.localRotation.x );
            waterSpawner.Stop();
            waterPoured = false;
        }
    }
}
