using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    //회전되는 스피드이다.
    
    public float CatminimumDistance;   //추적 범위
    public float CatSpeed;
    private GameObject target;  //타겟
    public GameObject bullet2;
    public GameObject bullet;
    public GameObject Potal;
    private bool isLife;
    private Animator Catanimator;
    public float coolTime;
    private float curTime;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        isLife = true;
        Catanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CatHpBar.CatCurrentHp <= 0)
        {
            Catanimator.SetTrigger("is_Die");
            Invoke("CatDie", 1f);
            isLife = false;
        }

        if(isLife == true)
        {
            attack();
        }


    }
    public void CatTakeDamage(int Damage)
    {
        CatHpBar.CatCurrentHp = CatHpBar.CatCurrentHp - Damage;
    }
    public void CatDie()
    {
        gameObject.SetActive(false);
        Potal.SetActive(true);
    }


    void attack()
    {
        if (Vector2.Distance(transform.position, target.transform.position) > 3.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, CatSpeed * Time.deltaTime);

            if (Time.time > curTime)
            {
                Catanimator.SetBool("is_Attack", true);
                shot();
                curTime = Time.time + coolTime;
            }
            else
            {
                Catanimator.SetBool("is_Attack", false);
            }
        }
        else if (Vector2.Distance(transform.position, target.transform.position) > 3.0f)
        {
            if (Time.time > curTime)
            {
                Catanimator.SetBool("is_Attack", true);
                Instantiate(bullet2, transform.position, Quaternion.identity);
                curTime = Time.time + coolTime;
            }
            else
            {
                Catanimator.SetBool("is_Attack", false);
            }
        }
        else if (Vector2.Distance(transform.position, target.transform.position) < CatminimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -CatSpeed * Time.deltaTime);
        }
    }


    void shot()
    {
        
        for (int i = 0; i < 360; i += 13)
        {
           
            GameObject temp = Instantiate(bullet);

            //2초마다 삭제
            Destroy(temp, 2f);

            
            temp.transform.position = gameObject.transform.position;

            //Z에 값이 변해야 회전이 이루어지므로, Z에 i를 대입한다.
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }
}
