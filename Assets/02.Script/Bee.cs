using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{

    public GameObject needle;

    public float coolTime;
    private float curTime;
    public float BeeSpeed;
    public float BeeminimumDistance;   //추적 범위

    public Animator BeeAnimator;

    private GameObject target;  //타겟
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        BeeAttack();
        Direction();

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
}
