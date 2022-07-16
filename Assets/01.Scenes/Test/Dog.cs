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
    public float rot_Speed;
    public GameObject bullet;
    private float EndTime = 2f;
    private float StartTime;
    public Animatior animatior;
    





    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Doganimatior = GetComponent<Animatior>();
    }

    // Update is called once per frame
    void Update()
    {
        StartTime += Time.deltaTime;

        if ( StartTime >= EndTime )
        {
            shot();
            StartTime = 0;
        }
        Direction();
        Dam();
        DogDie();
     
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

   void shot()
   {
       
        for (int i = 0; i < 360; i += 40)
        {
           
            GameObject temp = Instantiate(bullet);

            
            Destroy(temp, 2f);

            
            temp.transform.position = Vector2.zero;

            
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }

    public void DogDie()
    {
        if (curDogHp <= 0)

            DogAnimationController.SetTrigger("Is_Die");


    }
}
