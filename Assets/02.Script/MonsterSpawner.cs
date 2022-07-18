using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private bool isSpawner = true;

    public GameObject Monster1;
    public GameObject Monster2;
    public GameObject Monster3;
    public GameObject Monster4;
    public GameObject Monster5;
    public GameObject Monster6;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && isSpawner == true)
        {
            Invoke("MonsterSet", 0.5f);
            isSpawner = false;
        }
    }

    void MonsterSet()
    {
        Monster1.SetActive(true);
        Monster2.SetActive(true);
        Monster3.SetActive(true);
        Monster4.SetActive(true);
        Monster5.SetActive(true);
        Monster6.SetActive(true);
    }

}
