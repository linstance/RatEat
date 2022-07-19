using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyHell : MonoBehaviour
{
    public int flyHellHP = 6;

    public GameObject fireball;

    public float coolTime;  //쿨타임
    private float curTime;
    public float flyHellDistance; //추적 범위
    
    public Animator flyHellAnimator;    //애니메이터

    private GameObject target;  //타겟
    private bool IsLife = true; //벌 생존 여부

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (flyHellHP <= 0)
        {
            flyHellAnimator.SetTrigger("IsPlantDie");
            Invoke("flyHellDie", 1f);
            IsLife = false;
        }

        if (IsLife == true)
        {
            
            
         flyHellAttack();
            
            Direction();
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

    void flyHellAttack()
    {


        if (Time.time > curTime)
        {
            flyHellAnimator.SetBool("IsPlantAttack", true);
            Instantiate(fireball, transform.position, Quaternion.identity);
            curTime = Time.time + coolTime;
        }
        else
        {
            flyHellAnimator.SetBool("IsPlantAttack", false);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("충돌");
        if (collision.gameObject.tag == "PlayerBullet")
        {
            takeflyHelDamage(5);
            Debug.Log(flyHellHP);
        }
    }


    private void flyHellDie()
    {
        gameObject.SetActive(false);
    }


    public void takeflyHelDamage(int Damage)
    {
        flyHellHP = flyHellHP - Damage;
    }

    
}
