using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WarriorController : MonoBehaviour

    

    //전사생쥐에 움직임 및 전사생쥐의 기본적인 동작에 관련된 스크립트
{
    private bool AttackCheck = false; //현재 공격을 하고 있는지 체크 하는 변수

    public GameObject WarriorHitMash = null; //플레이어의 공격범위 오브젝트를 저장하는 변수 


    public static int currentDamage; //전사 생쥐가 현재 받을 데미지를 저장하는 변수

    private float WarriorCritical; //워리어의 치명타율을 저장하는 변수
    private float WarriorSpeed; //워리어의 속도를 저장하는 변수
    public static int WarrorHP; //워리어의 최대체력을 저장하는 변수
    public static int currentHP; //현재 워리어의 체력을 저장한는 변수
    public static int WarrorMP; //워리어의 마나를 저장하는 변수

    void Start()
    {
        PlayerStat playerStat = new PlayerStat(10,150,3.1f, 2.0f, "Warrior");
        WarriorSpeed = playerStat.PlayerSpeed;
        WarrorHP = playerStat.PlayerHP;
        currentHP = playerStat.PlayerHP;
        WarrorMP = playerStat.PlayerMP;
        WarriorCritical = playerStat.PlayerCritical;
        playerStat.CurrentPlayer(); //플레이어의 현재 상태를 출력하는 함수
    }

    
    void Update()
    {
        Move();
        Warriorattack();

        if(Input.GetKeyDown(KeyCode.H))
        {
            currentHP -= 1;
            Debug.Log("체력감소");
        }

        if(currentHP == 0)
        {
            Debug.Log("죽음");
        }
    }


    public void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inxputY = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector2(inputX, inxputY) * WarriorSpeed * Time.deltaTime);
    }

    public void Warriorattack()
    {
        if (Input.GetMouseButtonDown(0))//마우스 왼쪽 버튼을 클릭했을 경우
        {
            WarriorHitMash.SetActive(true);
            Debug.Log("공격");
        }
        else if (Input.GetMouseButtonUp(0))
        {
            WarriorHitMash.SetActive(false);
        } 
        
        if(Input.GetMouseButtonDown(1))//마우스 오른쪽 버튼을 클릭했을 경우
        {
            Debug.Log("무기 체인지");
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HitMash")
        {
           // WarrorHP =- currentDamage;
        }

        if(other.gameObject.tag == "needle")
        {
            currentHP = - 5;
        }
    }
}
