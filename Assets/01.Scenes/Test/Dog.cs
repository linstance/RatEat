﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dog : MonoBehaviour
{
   
    public static int DogHp = 50; //강아지 보스의 최대 체력을 정의한는 변수
    public static int CurDogHp = 50; //강아지 보스의 현재 체력을 정의한는 변수

    private GameObject target;  //타겟

    private bool isLife; //생존 여부

    public float rot_Speed; //회전속도
    public GameObject bullet;   //총알 오브젝트
    public GameObject Potal;
    private float EndTime = 4f; //딜레이
    private float StartTime; 

    public Animator Doganimator;    //애니메이터

    void Start()
    {
        isLife = true;
        target = GameObject.FindGameObjectWithTag("Player");
        Doganimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
      
        if(CurDogHp <= 0)
        {
            
            Doganimator.SetTrigger("Is_Die");
            Invoke("DogDie", 2f);
            isLife = false;
            Potal.SetActive(true);
        }

       if(isLife == true)
        {
            StartTime += Time.deltaTime;
            if (StartTime >= EndTime)
            {
                Doganimator.SetTrigger("IsBark");
                shot();
                StartTime = 0;
            }
            Direction();
            Dam();
            
        }
     
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            DogTakeDamage(5);
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
        StartCoroutine(hitdog());
    
     
    }

   void shot()
   {
       
        for (int i = 0; i < 360; i += 40)
        {
           
            GameObject temp = Instantiate(bullet);

            
            Destroy(temp, 2f);


            temp.transform.position = transform.position;

            
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }

    public void DogDie()
    {
        gameObject.SetActive(false);
    }
    IEnumerator hitdog()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
