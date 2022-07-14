using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redAnt : MonoBehaviour
{
    private GameObject target;  //타겟

    public int AttackPoint = 2;
    public int RedAntHp = 10; //개미 체력
    public float RedAntspeed; //이동속도
    public float RedAntminimumDistance;   //추적 범위
    public Animator RedAntAnimator;    //애니메이터


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

        if (RedAntHp <= 0)
        {
            RedAntAnimator.SetTrigger("IsAntDie");
            Invoke("redAntDie", 1f);
            IsLife = false;
        }

        if (IsLife == true)
        {
            RedAntMoveAttack();
            Direction();
        }

    }



    void RedAntMoveAttack()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > RedAntminimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, RedAntspeed * Time.deltaTime);
            RedAntAnimator.SetBool("IsAntAttack", false);
        }
        else
        {
            RedAntAnimator.SetBool("IsAntAttack", true);
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Player")
                {

                    if (curTime <= 0)
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

    public void takeRedAntDamage(int Damage)
    {
        RedAntHp = RedAntHp - Damage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

    private void redAntDie()
    {
        gameObject.SetActive(false);
    }
}
