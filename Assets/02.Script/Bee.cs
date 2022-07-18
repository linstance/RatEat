using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public int BeeHp = 6;

    public GameObject needle;

    public float coolTime;
    private float curTime;
    public float BeeSpeed;
    public float BeeminimumDistance;   //추적 범위

    public Animator BeeAnimator;

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
        if (BeeHp <= 0)
        {
            BeeAnimator.SetTrigger("IsBeeDie");
            Invoke("BeeDie", 1f);
            IsLife = false;
        }

        if(IsLife == true)
        {
            BeeAttack();
            Direction();
        }
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            takeBeeDamage(5);
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

    void BeeAttack()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > 3.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, BeeSpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.transform.position) < BeeminimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -BeeSpeed * Time.deltaTime);
        }

        if (Time.time > curTime)
        {
            BeeAnimator.SetBool("IsBeeAttack", true);
            Instantiate(needle, transform.position, Quaternion.identity);
            curTime = Time.time + coolTime;
        }
        else
        {
            BeeAnimator.SetBool("IsBeeAttack", false);
        }

    }

    private void BeeDie()
    {
        gameObject.SetActive(false);
    }


    public void takeBeeDamage(int Damage)
    {
        BeeHp = BeeHp - Damage;
    }
}
