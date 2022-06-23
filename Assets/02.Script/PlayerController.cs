using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
    //플레이어에 움직임 및 플레이어의 기본적인 동작에 관련된 스크립트
{
    public float MoveSpeed = 3.5f;
    void Start()
    {
        
    }

    
    void Update()
    {
        Move();
    }


    public void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inxputY = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector2(inputX, inxputY) * MoveSpeed * Time.deltaTime);
    }
}
