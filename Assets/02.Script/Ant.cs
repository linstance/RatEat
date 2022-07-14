using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{

    private GameObject target;  //타겟

    public int AttackPoint = 2;
    public int AntHp = 10; //개미 체력
    public float speed; //이동속도
    public float minimumDistance;   //추적 범위
    public Animator AntAnimator;    //애니메이터


    public Transform pos;   //히트박스 위치
    public Vector2 boxSize; //공격범위 크기

    private float curTime;
    public float coolTime = 0.5f; //공격 딜레이

    private bool IsLife = true; //개미의 생존여부

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        Debug.Log(AntHp);

        if(AntHp <= 0)
        {
            AntAnimator.SetTrigger("IsAntDie");
            Invoke("AntDie", 1f);
            IsLife = false;
        }

        if(IsLife == true)
        {
            MoveAttack();
            Direction();
        }
        
    }



    void MoveAttack()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            AntAnimator.SetBool("IsAntAttack", false);
        }
        else
        {
            AntAnimator.SetBool("IsAntAttack", true);
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Player")
                {
                   
                    if(curTime <= 0)
                    {
                        WarriorController.currentHP = WarriorController.currentHP - AttackPoint;
                        curTime = coolTime;
                    }
                    else
                    {
                        curTime -= Time.deltaTime;
                    }
                }
            }
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

    public void takeAntDamage(int Damage)
    {
       AntHp =  AntHp - Damage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

    private void AntDie()
    {
        gameObject.SetActive(false);
    }

}
