using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject Sword;
    public GameObject Sword2;
    public GameObject Sword3;
    public GameObject ani;
    Animator animator;

    int r;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        r = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.gameObject.tag == "Player")
        {

            animator.SetBool("Open", true);
            Sword.gameObject.SetActive(true);
            
            {
                if (r == 0)
                {

                    ani.gameObject.SetActive(true);
                    Sword.gameObject.SetActive(true);
                    Sword2.gameObject.SetActive(false);
                    Sword3.gameObject.SetActive(false);
                }
                if (r == 1)
                {
                    ani.gameObject.SetActive(true);
                    Sword2.gameObject.SetActive(true);
                    Sword.gameObject.SetActive(false);
                    Sword3.gameObject.SetActive(false);
                }
                if (r == 2)
                {
                    ani.gameObject.SetActive(true);
                    Sword3.gameObject.SetActive(true);
                    Sword.gameObject.SetActive(false);
                    Sword2.gameObject.SetActive(false);
                }
            }
            

            

        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.F))
        {
            Destroy(Sword);
            Destroy(Sword2);
            Destroy(Sword3);
        }

    }

   private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
               if(Input.GetKey(KeyCode.F))
            {
                Destroy(Sword);
                Destroy(Sword2);
                Destroy(Sword3);
            }
               else
            {


            }
            

        }

        }

    
}
