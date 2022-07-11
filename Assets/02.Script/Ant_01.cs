using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant_01 : MonoBehaviour
{

    private GameObject target;  //타겟

    public float speed; //이동속도
    public float minimumDistance;   //추적 범위

    public Animator AntAnimator;

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    private void Update()
    {

        MoveAttack();
        Direction();
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

}
