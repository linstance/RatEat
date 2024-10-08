﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float distance;
    public LayerMask isLayer;
    public float speed;
    public float atkDistance;

    public GameObject sting2;
    public Transform pos;
    // Start is called before the first frame update


    void Start()
    {
   
    }

 

    // Update is called once per frame
    void Update()
    {
        
    }

    public float cooltime;
    private float currenttime;
     void FixedUpdate()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLayer);
        if(raycast.collider != null)
        {
            if(Vector2.Distance(transform.position, raycast.collider.transform.position) < atkDistance)
            {
                if (currenttime <= 0)
                {
                    GameObject bulletcopy = Instantiate(sting2, pos.position, transform.rotation);
                    currenttime = cooltime;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, raycast.collider.transform.position, Time.deltaTime * speed);

            }
            currenttime -= Time.deltaTime;
        } 

    }
}
