using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{

    public GameObject ant1;
    public GameObject ant2;
    public GameObject ant3;
    public GameObject ant4;

    public GameObject OpenGate;
    public GameObject CloseGate;

    public static  bool Room1 = false;


    private void Update()
    {

        

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"&& Room1 == false)
        {
            OpenGate.SetActive(false);
            CloseGate.SetActive(true);

            ant1.SetActive(true);
            ant2.SetActive(true);
            ant3.SetActive(true);
            ant4.SetActive(true);

            Room1 = true;
        }
    }
}
