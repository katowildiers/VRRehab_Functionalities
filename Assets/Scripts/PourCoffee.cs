using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourCoffee : MonoBehaviour
{
    public ParticleSystem coffeeParticles;
    public GameObject foamObject;
    private bool coffeePoured;
    public GameObject coffeeCup;
    private bool firstTime= true;

    // Start is called before the first frame update
    void Start()
    {
        coffeeParticles.Stop();
        coffeeParticles.enableEmission = false;
        coffeePoured = false;
    }

    private void Update()
    {
        print(coffeePoured);
        
        if (foamObject.transform.localPosition.y >= 0.14)
        {
            coffeePoured = true;
        }

        if (coffeePoured)
        {
            Debug.Log("Stopped pouring");
            coffeeParticles.Stop();
            coffeePoured = false;
            coffeeCup.GetComponent<AddFoam>().stoppedPooring();
        }
    }

    public void buttonPressed()
    {
        if (firstTime == true){
            firstTime = false;
        }
        else
        {
            Debug.Log("Pouring coffee");
            coffeeParticles.enableEmission = true;
            coffeeParticles.Play();
            //coffeePoured = true;
            coffeeCup.GetComponent<AddFoam>().startedPooring();
        }  
    }
}
