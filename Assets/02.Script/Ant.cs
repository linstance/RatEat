using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    private GameObject player;
    public float movespeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;// Start is called before the first frame update
    public static int antHP = 6;


    Animator animator;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");

        animator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
 
            Debug.Log("충돌 유지");
            animator.SetBool("IsAntHit", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Debug.Log("충돌 끝남");
            animator.SetBool("IsAntHit", false);
        }

        if(collision.gameObject.tag == "BronzeSword")
        {
            antHP -= 2;
        }

    }


    // Update is called once per frame
    void Update()
    {

        if(antHP == 0)
        {
            gameObject.SetActive(false);
        }



        /* Vector3 direction = player.position - transform.position;
        //float angle2 = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
       // rb.rotation = angle2;
        direction.Normalize();
        movement = direction;

        //추가
        Vector3 dir = target.transform.position - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up); */


        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        


    }
    private void FixedUpdate()
    {
        moveChracter(movement);
    }
    void moveChracter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movespeed * Time.deltaTime));
    }

 

    }
