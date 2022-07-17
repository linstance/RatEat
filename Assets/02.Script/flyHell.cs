using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyHell : MonoBehaviour
{
    public int flyHellHP = 6;

    public GameObject fireball;

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
        if (flyHellHP <= 0)
        {
            BeeAnimator.SetTrigger("IsPlantDie");
            Invoke("flyHelDie", 1f);
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

         if (Vector2.Distance(transform.position, target.transform.position) < BeeminimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -BeeSpeed * Time.deltaTime);
        }

        if (Time.time > curTime)
        {
            BeeAnimator.SetBool("IsPlantAttack", true);
            Instantiate(fireball, transform.position, Quaternion.identity);
            curTime = Time.time + coolTime;
        }
        else
        {
            BeeAnimator.SetBool("IsBeeAttack", false);
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
