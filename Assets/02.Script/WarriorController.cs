using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WarriorController : MonoBehaviour

    //전사생쥐에 움직임 및 전사생쥐의 기본적인 동작에 관련된 스크립트
{
    bool isinvi = false;
    private float curTime;
    public float coolTime = 0.5f; //공격 딜레이

    private float inputX; // 움직임의 수직값
    private float inputY; // 움직임의 높이값

   
    private int CurrentSkill;   //현재 스킬

    public Animator warriorAnimator; //워리어 애니메이터
    public static int currentDamage; //전사 생쥐가 현재 받을 데미지를 저장하는 변수

    
    private float WarriorSpeed; //워리어의 속도를 저장하는 변수

    public static int WarrorHP; //워리어의 최대체력을 저장하는 변수
    public static int currentHP; //현재 워리어의 체력을 저장한는 변수
    public static int WarrorMP; //워리어의 마나를 저장하는 변수
    public static int currentMP;//현재 워리어의 마나를 저장한는 변수

    public GameObject[] Weapon;// 무기를 담을 배열
    public GameObject[] Skills;// 스킬 UI배열

    public Transform pos;   //히트박스 위치
    public Vector2 boxSize; //공격범위 크기

    private int CurrntAttackPoint;//현재 공격력

    public AudioClip AttackBgm;
    public AudioSource PlayerAdo;
    public GameObject PlayerBullet; //플레이어가 쏘는 화염구
                                 

    void Start()
    {
        CurrntAttackPoint = 3;
        Debug.Log("현재 공격력:" + CurrntAttackPoint);

         warriorAnimator = GetComponent<Animator>();
        PlayerStat playerStat = new PlayerStat(10,150, 4f, "Warrior");
        WarriorSpeed = playerStat.PlayerSpeed;
        WarrorHP = playerStat.PlayerHP;
        currentHP = playerStat.PlayerHP;
        WarrorMP = playerStat.PlayerMP;
        currentMP = playerStat.PlayerMP;
        playerStat.CurrentPlayer(); //플레이어의 현재 상태를 출력하는 함수

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
                    if (collider.tag == "Dumi")
                    {
                        collider.GetComponent<Dumi>().takeAntDamage(CurrntAttackPoint);
                    }
                    if (collider.tag == "redAnt")
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
                        collider.GetComponent<Bee>().takeBeeDamage(CurrntAttackPoint);
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

        if (Input.GetKeyDown(KeyCode.Space) && CurrentSkill == 1 && currentMP > 0)
        {
            if (currentMP > 0)
            {
                Skill_01();
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && CurrentSkill == 2 && currentMP > 0)
        {
            if (currentMP > 0)
            {
                Skill_02();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && CurrentSkill == 3 && currentMP > 0)
        {
            if (currentMP > 0)
            {
                Skill_03();
            }
               
        }

    }


    private void HpTest()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            currentHP -= 5;
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

    

    void AllWeaponDeactive()    //무기 자동 비활성화
    {
        foreach (GameObject wea in Weapon)
        {
            wea.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "needle")
        {
            PlayerTakeDamage(1);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "BronzeSword" && Input.GetKey(KeyCode.F))
        {
            //동검 rare
            AllWeaponDeactive();
            Weapon[0].SetActive(true);
            CurrntAttackPoint = 5;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "needleSword" && Input.GetKey(KeyCode.F))
        {
            //바늘검 Common
            
            AllWeaponDeactive();
            Weapon[2].SetActive(true);
            CurrntAttackPoint = 3;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);
        }

    
    

        if (other.gameObject.tag == "IceSword" && Input.GetKey(KeyCode.F))
        {
            //빙뢰검 Epic
            

            AllWeaponDeactive();
            Weapon[1].SetActive(true);
            CurrntAttackPoint = 8;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);
        }
        
        if (other.gameObject.tag == "Banana" && Input.GetKey(KeyCode.F))
        {
            //바나나 Common
            AllWeaponDeactive();
            Weapon[3].SetActive(true);
            CurrntAttackPoint = 3;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "Bet" && Input.GetKey(KeyCode.F))
        {
            //방망이 Common
            AllWeaponDeactive();
            Weapon[4].SetActive(true);
            CurrntAttackPoint = 3;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "Candy" && Input.GetKey(KeyCode.F))
        {
            //사탕 Common
            AllWeaponDeactive();
            Weapon[5].SetActive(true);
            CurrntAttackPoint = 3;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "Cane" && Input.GetKey(KeyCode.F))
        {
            //지팡이 Common
            AllWeaponDeactive();
            Weapon[6].SetActive(true);
            CurrntAttackPoint = 3;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "Carrot" && Input.GetKey(KeyCode.F))
        {
            //당근 Common
            AllWeaponDeactive();
            Weapon[7].SetActive(true);
            CurrntAttackPoint = 3;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "Dumbbell" && Input.GetKey(KeyCode.F))
        {
            //덤벨 Common
            AllWeaponDeactive();
            Weapon[8].SetActive(true);
            CurrntAttackPoint = 3;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "Earpick" && Input.GetKey(KeyCode.F))
        {
            //귀이개 rare
            AllWeaponDeactive();
            Weapon[9].SetActive(true);
            CurrntAttackPoint = 5;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "Flower" && Input.GetKey(KeyCode.F))
        {
            //꽃 Common
            AllWeaponDeactive();
            Weapon[10].SetActive(true);
            CurrntAttackPoint = 3;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "Grass" && Input.GetKey(KeyCode.F))
        {
            //풀떼기 Common
            AllWeaponDeactive();
            Weapon[11].SetActive(true);
            CurrntAttackPoint = 3;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "Hammer" && Input.GetKey(KeyCode.F))
        {
            //망치 rare
            AllWeaponDeactive();
            Weapon[12].SetActive(true);
            CurrntAttackPoint = 5;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "Icecream" && Input.GetKey(KeyCode.F))
        {
            //아이스크림 Common
            AllWeaponDeactive();
            Weapon[13].SetActive(true);
            CurrntAttackPoint = 3;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "Legend" && Input.GetKey(KeyCode.F))
        {
            //불검 Common
            AllWeaponDeactive();
            Weapon[14].SetActive(true);
            CurrntAttackPoint = 3;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "Pan" && Input.GetKey(KeyCode.F))
        {
            //프라이팬 rare
            AllWeaponDeactive();
            Weapon[15].SetActive(true);
            CurrntAttackPoint = 5;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "Pencil" && Input.GetKey(KeyCode.F))
        {
            //연필 Common
            AllWeaponDeactive();
            Weapon[16].SetActive(true);
            CurrntAttackPoint = 3;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "Pepero" && Input.GetKey(KeyCode.F))
        {
            //빼빼로 Common
            AllWeaponDeactive();
            Weapon[17].SetActive(true);
            CurrntAttackPoint = 3;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "Plunger" && Input.GetKey(KeyCode.F))
        {
            //뚜러 rare
            AllWeaponDeactive();
            Weapon[18].SetActive(true);
            CurrntAttackPoint = 5;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }
        
        if (other.gameObject.tag == "Shovel" && Input.GetKey(KeyCode.F))
        {
            //삽 Common
            AllWeaponDeactive();
            Weapon[19].SetActive(true);
            CurrntAttackPoint = 3;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "Umbrella" && Input.GetKey(KeyCode.F))
        {
            //우산
            //Common
            AllWeaponDeactive();
            Weapon[20].SetActive(true);
            CurrntAttackPoint = 3;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }

        if (other.gameObject.tag == "MoonNightSword" && Input.GetKey(KeyCode.F))
        {
            //문나이트 소드 전설
            AllWeaponDeactive();
            Weapon[21].SetActive(true);
            CurrntAttackPoint = 24;

            Debug.Log("현재공격력 :" + CurrntAttackPoint);

        }


        if (other.gameObject.tag == "Skill1" && Input.GetKey(KeyCode.F))
        {
            Skills[0].SetActive(true);
            Skills[1].SetActive(false);
            Skills[2].SetActive(false);
            CurrentSkill = 1;

        }

        if (other.gameObject.tag == "Skill2" && Input.GetKey(KeyCode.F))
        {
            Skills[0].SetActive(false);
            Skills[1].SetActive(true);
            Skills[2].SetActive(false);
            CurrentSkill = 2;

        }

        if (other.gameObject.tag == "Skill3" && Input.GetKey(KeyCode.F))
        {
            Skills[0].SetActive(false);
            Skills[1].SetActive(false);
            Skills[2].SetActive(true);
            CurrentSkill = 3;

        }

    }


    void Skill_01()
    {
        currentMP -= 30;
        if ( currentHP < 10 )
        {
            WarriorController.currentHP += 1;
        }
        if ( currentHP >= 10 )
        {
            WarriorController.currentHP += 0;
        }
            
        
    }

    void Skill_02()
    {
        currentMP -= 30;
        
        StartCoroutine(NoHit());   
    }

    void Skill_03()
    {
        currentMP -= 30;

        for (int i = 0; i < 360; i += 90)
        {
            GameObject temp = Instantiate(PlayerBullet);

            temp.transform.position = pos.position;

            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
           
       

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }


    public void PlayerTakeDamage(int Damage)
    {
        if(isinvi == false)
        {
            currentHP = currentHP - Damage;
            warriorAnimator.SetBool("IsHit",true);
            Invoke("SetFalseHit", 1f);
        }
        
        if(isinvi == true)
        {
            Damage = 0;
            currentHP = currentHP - Damage;
            //warriorAnimator.SetBool("IsHit",false);
        }

    }

    void SetFalseHit()
    {
        warriorAnimator.SetBool("IsHit", false);
    }

    IEnumerator NoHit()
    {
        
        isinvi = true;
        GetComponent<SpriteRenderer>().color = Color.yellow;

        yield return new WaitForSeconds(3.0f);

        GetComponent<SpriteRenderer>().color = Color.white;
        isinvi = false;
    }


}
