using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject Sword;
    public GameObject Sword2;
    Animator animator;

    int r;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
            r = Random.Range(0, 2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("Open", true);
            Sword.gameObject.SetActive(true);
            
            if (r == 0)
            {
                Sword.gameObject.SetActive(true);
                Sword2.gameObject.SetActive(false);
            }
            if (r == 1)
            {
                Sword2.gameObject.SetActive(true);
                Sword.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("Open", false);
                Sword.gameObject.SetActive(false);
                Sword2.gameObject.SetActive(false);
        }

        }

    
}
