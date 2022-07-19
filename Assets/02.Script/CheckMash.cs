using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMash : MonoBehaviour
{
    /*
      개미: Ant
      불개미: redAnt
      파리지옥 flyHell
      벌: Bee
    */

    private GameObject OpenGate;
    private GameObject CloseGate;
    private int Monster = 0;

    // Start is called before the first frame update
    void Start()
    {
        OpenGate = GameObject.FindGameObjectWithTag("OpenGate");
        CloseGate = GameObject.FindGameObjectWithTag("CloseGate");
    }

    // Update is called once per frame
    void Update()
    {
        check();
    }


    void check()
    {
        GameObject[] Ants = GameObject.FindGameObjectsWithTag("Ant");
        GameObject[] redAnts = GameObject.FindGameObjectsWithTag("redAnt");
        GameObject[] Spiders = GameObject.FindGameObjectsWithTag("Spider");
        GameObject[] Flys = GameObject.FindGameObjectsWithTag("Fly");
        GameObject[] FlyHells = GameObject.FindGameObjectsWithTag("flyHell");
        GameObject[] Bees = GameObject.FindGameObjectsWithTag("Bee");
        GameObject[] Dog = GameObject.FindGameObjectsWithTag("Dog");
        GameObject[] Cat = GameObject.FindGameObjectsWithTag("Cat");

        if (Monster < Ants.Length || Monster < redAnts.Length || Monster < Spiders.Length || Monster < Flys.Length || Monster < FlyHells.Length || Monster < Bees.Length || Monster < Dog.Length || Monster < Cat.Length)
        {
            OpenGate.SetActive(false);
            CloseGate.SetActive(true);
        }
        else if (Monster <= Ants.Length || Monster <= redAnts.Length || Monster <= Spiders.Length || Monster <= Flys.Length || Monster <= FlyHells.Length || Monster <= Bees.Length || Monster <= Dog.Length || Monster <= Cat.Length)
        {
            OpenGate.SetActive(true);
            CloseGate.SetActive(false);
        }
    }
   
}
