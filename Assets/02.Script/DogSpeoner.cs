using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSpeoner : MonoBehaviour
{
    public GameObject Dog;
    public GameObject Bar;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("DogSet", 0.5f);
        }
    }

    void DogSet()
    {
        Dog.SetActive(true);
        Bar.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
