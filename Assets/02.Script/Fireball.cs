using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Vector3 target;  //타겟
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<WarriorController>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);

        if (transform.position == target)
        {
            Destroy(gameObject);
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }

    }
}
