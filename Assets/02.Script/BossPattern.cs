﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern : MonoBehaviour
{
    //회전되는 스피드이다.
    public float rot_Speed;
    public float HP;
    bool A;
    //총알이 발사될 위치이다.
    public Transform pos;

    //발사될 총알 오브젝트이다.
    public GameObject bullet;

    public float Delaytime = 0.3f;
    private float ShotTime;
    int isDeal;

    private void Start()
    {
        
    }


    private void Update()
    {
        ShotTime += Time.deltaTime;

        //회전
        transform.Rotate(Vector3.forward * rot_Speed * 100 * Time.deltaTime);

        if (ShotTime >= Delaytime && HP >= 100)
        {
            ShotTime = 0;
 

            //총알 생성
            GameObject temp = Instantiate(bullet);

            //2초후 자동 삭제
            Destroy(temp, 2f);

            //총알 생성 위치를 머즐 입구로 한다.
            temp.transform.position = transform.position;

            //총알의 방향을 오브젝트의 방향으로 한다.
            //->해당 오브젝트가 오브젝트가 360도 회전하고 있으므로, Rotation이 방향이 됨.
            temp.transform.rotation = transform.rotation;


        }

        if( HP < 100 && !A)
        {
            
            ShotTime = 0;
            Delaytime = 2F;
            A = true;

        }

        if ( ShotTime >= Delaytime && A)
        {
            if(isDeal < 1)
            {
                ShotTime = 0;
                shot();
            }
            else
            {
                StartCoroutine(Delay());
            }


        }
        



    }
    void shot()
    {
        isDeal += 1;
        //360번 반복
        for (int i = 0; i < 360; i += 40)
        {
            //총알 생성
            GameObject temp = Instantiate(bullet);

            //2초마다 삭제
            Destroy(temp, 2f);

            //총알 생성 위치를 (0,0) 좌표로 한다.
            temp.transform.position = transform.position;

            //Z에 값이 변해야 회전이 이루어지므로, Z에 i를 대입한다.
            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5f);
        isDeal = 0;
    }

}
