using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant_01 : MonoBehaviour
{

    private GameObject Target;  //타겟

    public Collider2D AttackMash;   //공격 범위
    public Collider2D TrackingMash; //추적 범위
    public Transform Ant;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float Distans = Vector3.Distance(Target.transform.position, Ant.position);
         
        
    }

    private void OnTriggerEnter2D(Collider2D other) //충돌시 1회 출력
    {
        if(other.gameObject.tag == "Player")
        {

        }
    }

    private void OnTriggerStay2D(Collider2D others) //충돌 중일때 지속적으로 출력
    {
        
    }


    public void AntMove()
    {
        
    }

    public void AntAttack()
    {

    }
}
