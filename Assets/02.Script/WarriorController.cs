using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WarriorController : MonoBehaviour

    

    //전사생쥐에 움직임 및 전사생쥐의 기본적인 동작에 관련된 스크립트
{
    

    private float curTime;
    public float coolTime = 0.5f; //공격 딜레이

    private float inputX; // 움직임의 수직값
    private float inputY; // 움직임의 높이값

    public GameObject GameManager;

    public Animator warriorAnimator; //워리어 애니메이터
    public static int currentDamage; //전사 생쥐가 현재 받을 데미지를 저장하는 변수

    
    private float WarriorSpeed; //워리어의 속도를 저장하는 변수

    public static int WarrorHP; //워리어의 최대체력을 저장하는 변수
    public static int currentHP; //현재 워리어의 체력을 저장한는 변수
    public static int WarrorMP; //워리어의 마나를 저장하는 변수
    public static int currentMP;//현재 워리어의 마나를 저장한는 변수

    public GameObject[] Weapon;// 무기를 담을 배열

    public Transform pos;   //히트박스 위치
    public Vector2 boxSize; //공격범위 크기

    private int CurrntAttackPoint;//현재 공격력

    public AudioClip AttackBgm;
    public AudioSource PlayerAdo;

    void Start()
    {
        CurrntAttackPoint = 2;
        Debug.Log("현재 공격력:" + CurrntAttackPoint);

         warriorAnimator = GetComponent<Animator>();
        PlayerStat playerStat = new PlayerStat(10,150, 4f, "Warrior");
        WarriorSpeed = playerStat.PlayerSpeed;
        WarrorHP = playerStat.PlayerHP;
        currentHP = playerStat.PlayerHP;
        WarrorMP = playerStat.PlayerMP;
        currentMP = playerStat.PlayerMP;
        playerStat.CurrentPlayer(); //플레이어의 현재 상태를 출력하는 함수

        GameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void Awake()
    {
        PlayerAdo = GetComponent<AudioSource>();
    }

    void Update()
    {
        Warriorattack();
        CallDie();
        Move();
        HpTest();
    }



    public void Move()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            warriorAnimator.SetBool("IsMove", true);
            transform.localEulerAngles = new Vector3(0, 0, 0);

        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            warriorAnimator.SetBool("IsMove", false);
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            warriorAnimator.SetBool("IsMove", true);
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            warriorAnimator.SetBool("IsMove", false);
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            warriorAnimator.SetBool("IsMove", true);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            warriorAnimator.SetBool("IsMove", false);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            warriorAnimator.SetBool("IsMove", true);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            warriorAnimator.SetBool("IsMove", false);
        }


         inputX = Input.GetAxisRaw("Horizontal") * WarriorSpeed * Time.deltaTime;
        inputY = Input.GetAxisRaw("Vertical") * WarriorSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + inputX, transform.position.y + inputY);
    }

    public void Warriorattack()
    {

        if(curTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                PlayerAdo.PlayOneShot(AttackBgm);
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach(Collider2D collider in collider2Ds)
                {
                   
                    if(collider.tag == "Ant")
                    {
                        collider.GetComponent<Ant>().takeAntDamage(CurrntAttackPoint);
                    }

                     if(collider.tag == "redAnt")
                    {
                        collider.GetComponent<redAnt>().takeRedAntDamage(CurrntAttackPoint);
                    }
                    else if(collider.tag == "Fly")
                    {
                        collider.GetComponent<Ant>().takeAntDamage(CurrntAttackPoint);
                    }
                    else if (collider.tag == "flyHell")
                    {
                        collider.GetComponent<Ant>().takeAntDamage(CurrntAttackPoint);
                    }
                    else if (collider.tag == "Spider")
                    {
                        collider.GetComponent<Ant>().takeAntDamage(CurrntAttackPoint);
                    }
                    else if (collider.tag == "Bee")
                    {
                        collider.GetComponent<Ant>().takeAntDamage(CurrntAttackPoint);
                    }
                    else if(collider.tag == "Dog")
                    {
                        collider.GetComponent<Dog>().DogTakeDamage(CurrntAttackPoint);
                    }
                }

                curTime = coolTime;

                warriorAnimator.SetBool("IsAttack", true);
               
            }
        }
       else
        {
            curTime -= Time.deltaTime;
            warriorAnimator.SetBool("IsAttack", false);

        }

    }


    private void HpTest()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            currentHP -= 100;
            Debug.Log("체력감소");
        }
    }


    public void CallDie()
    {
        if (currentHP <= 0)
        {
            Debug.Log(currentHP);
            warriorAnimator.SetTrigger("IsDie"); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "needle")
        {
            currentHP = currentHP - 1;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "BronzeSword" && Input.GetKey(KeyCode.F))
        {
            //동검 Common
            Weapon[0].SetActive(true);
            
            Weapon[1].SetActive(false);
            Weapon[2].SetActive(false);
            CurrntAttackPoint = 4;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "needleSword" && Input.GetKey(KeyCode.F))
        {
            //바늘검 Common
            Weapon[2].SetActive(true);

            Weapon[0].SetActive(false);
            Weapon[1].SetActive(false);
            CurrntAttackPoint = 2;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);
        }

        if (other.gameObject.tag == "IceSword" && Input.GetKey(KeyCode.F))
        {
            //빙뢰검 Epic
            Weapon[1].SetActive(true);

            Weapon[0].SetActive(false);
            Weapon[2].SetActive(false);
            CurrntAttackPoint = 8;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

    public void OnDieEvent()
    {
      
    }

    public void PlayerTakeDamage(int Damage)
    {
        currentHP = currentHP - Damage;
        warriorAnimator.SetBool("IsHit", true);
    }

}
