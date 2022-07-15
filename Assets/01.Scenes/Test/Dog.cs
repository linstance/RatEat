using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public static int DogHp = 50;
    public static int CurDogHp = 50;

    private GameObject target;
    private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Direction();
        Dam();
    }


    void Direction()
    {
        if (target.transform.position.x > transform.position.x)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        else if (target.transform.position.x < transform.position.x)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }

   void Dam()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            CurDogHp = CurDogHp - 1;
        }
    }

    public void DogTakeDamage(int Damage)
    {
        CurDogHp = CurDogHp - Damage;
    }
}
