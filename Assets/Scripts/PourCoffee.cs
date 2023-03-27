using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourCoffee : MonoBehaviour
{
    public ParticleSystem coffeeParticles;
    private bool coffeePoured;
    public GameObject coffeeCup;
    // Start is called before the first frame update
    void Start()
    {
        coffeeParticles.Stop();
        coffeePoured = false;
    }
    public void buttonPressed()
    {
        if (!coffeePoured)
        {
            Debug.Log("Pouring coffee");
            coffeeParticles.Play();
            coffeePoured = true;
            coffeeCup.GetComponent<AddFoam>().startPooring();
        }
        else if (coffeePoured)
        {
            Debug.Log("Stopped pouring");
            coffeeParticles.Stop();
            coffeePoured = false;
            coffeeCup.GetComponent<AddFoam>().stopPooring();
        }
    }
}
