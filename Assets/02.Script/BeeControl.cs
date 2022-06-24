using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeControl : MonoBehaviour
{
    Rigidbody2D rb;
    Transform target;

    [Header("추적속도")]
    [SerializeField] [Range(-4f, 4f)] float moveSpeed = 3f;

    [Header("근접 거리")]
    [SerializeField] [Range(-4f, 4f)] float contactDistance = 1f;

    bool follow = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }


    private void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        if (Vector2.Distance(transform.position, target.position) > contactDistance && follow)
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
    
    public void follower()
    {
        
        follow = true;
        //
    }

    public void followerfalse()
    {

        follow = false;
        //
    }
}
