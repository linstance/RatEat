using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WarriorController : MonoBehaviour

    

    //전사생쥐에 움직임 및 전사생쥐의 기본적인 동작에 관련된 스크립트
{



    private int WarriorHP = 11; //전사 생쥐의 HP를 담고 있는 변수
    private int WarriorMP = 150; //전사 생쥐의 MP를 담고 있는 변수

    private bool AttackCheck = false; //현재 공격을 하고 있는지 체크 하는 변수

    public float WarriorCri = 50f;  //전사 생쥐의 크리티컬 확율
    public float MoveSpeed = 3.5f;  //전사 생쉬의 이동 속도

    public GameObject WarriorHitMash = null; //플레이어의 공격범위 오브젝트를 저장하는 변수 


    public static int currentDamage;


    void Start()
    {
        
    }

    
    void Update()
    {
        Move();
    }


    public void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inxputY = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector2(inputX, inxputY) * MoveSpeed * Time.deltaTime);
    }

    public void Warriorattack()
    {
        if (Input.GetMouseButtonDown(0))//마우스 왼쪽 버튼을 클릭했을 경우
        {
            WarriorHitMash.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            WarriorHitMash.SetActive(false);
        } 
        
        if(Input.GetMouseButtonDown(1))//마우스 오른쪽 버튼을 클릭했을 경우
        {

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HitMash")
        {
            WarriorHP =- currentDamage;
        }

        if(other.gameObject.tag == "")
        {

        }
    }
}
