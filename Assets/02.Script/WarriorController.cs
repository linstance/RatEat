using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WarriorController : MonoBehaviour

    

    //전사생쥐에 움직임 및 전사생쥐의 기본적인 동작에 관련된 스크립트
{
    

    private float curTime;
    public float coolTime = 0.5f;

    private float inputX; // 움직임의 수직값
    private float inputY; // 움직임의 높이값

    private bool AttackCheck = false; //현재 공격을 하고 있는지 체크 하는 변수

    public Animator warriorAnimator; //워리어 애니메이터
    public Animator effactAnimator; //이펙트 애니메이터

    public static int currentDamage; //전사 생쥐가 현재 받을 데미지를 저장하는 변수

    private float WarriorCritical; //워리어의 치명타율을 저장하는 변수
    private float WarriorSpeed; //워리어의 속도를 저장하는 변수

    public static int WarrorHP; //워리어의 최대체력을 저장하는 변수
    public static int currentHP; //현재 워리어의 체력을 저장한는 변수
    public static int WarrorMP; //워리어의 마나를 저장하는 변수
    public static int currentMP;//현재 워리어의 마나를 저장한는 변수

    public GameObject[] Weapon;

    public Transform pos;
    public Vector2 boxSize;

    void Start()
    {
        

         warriorAnimator = GetComponent<Animator>();
        PlayerStat playerStat = new PlayerStat(10,150,4f, 2.0f, "Warrior");
        WarriorSpeed = playerStat.PlayerSpeed;
        WarrorHP = playerStat.PlayerHP;
        currentHP = playerStat.PlayerHP;
        WarrorMP = playerStat.PlayerMP;
        currentMP = playerStat.PlayerMP;
        WarriorCritical = playerStat.PlayerCritical;
        playerStat.CurrentPlayer(); //플레이어의 현재 상태를 출력하는 함수
    }

    
    void Update()
    {
        Move();
        CallDie();
        Warriorattack();
       

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
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach(Collider2D collider in collider2Ds)
                {
                    Debug.Log(collider.tag);
                }

                curTime = coolTime;


                warriorAnimator.SetBool("IsAttack", true);
                AttackCheck = true;

                if(AttackCheck == true)
                {
                    effactAnimator.SetBool("IsEffact", true);
                }
               
            }
        }
       else
        {
            curTime -= Time.deltaTime;
            AttackCheck = false;
            warriorAnimator.SetBool("IsAttack", false);
         
            if(AttackCheck == false)
            {
                effactAnimator.SetBool("IsEffact", false);
            }

        }

    }


    private void HpTest()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            currentHP -= 1;
            Debug.Log("체력감소");
        }
    }


    public void CallDie()
    {
        if (currentHP <= 0)
        {
            warriorAnimator.SetBool("isDie", true); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "needle")
        {
           currentHP -= 1;
        }
        if(other.gameObject.tag == "bee")
        {
            currentHP -= 1;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "BronzeSword" && Input.GetKey(KeyCode.F))
        {
            Weapon[0].SetActive(true);
            
            Weapon[1].SetActive(false);
            Weapon[2].SetActive(false);

        }

        if (other.gameObject.tag == "needleSword" && Input.GetKey(KeyCode.F))
        {
            Weapon[2].SetActive(true);

            Weapon[0].SetActive(false);
            Weapon[1].SetActive(false);
        }

        if (other.gameObject.tag == "IceSword" && Input.GetKey(KeyCode.F))
        {
            Weapon[1].SetActive(true);

            Weapon[0].SetActive(false);
            Weapon[2].SetActive(false);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

    
}
