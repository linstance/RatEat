using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat
{
    public int PlayerHP { get; set; }
    public float PlayerSpeed { get; set; } //플레이어 속도
    public float PlayerCritical { get; set; } //플레이어 크리티컬
    public string PlayerClassName { get; set; } //플레이어 클래스 이름


    public PlayerStat(int PlayerHP, float PlayerSpeed, float PlayerCritical, string PlayerClassName)//플레이어의 체력 이동속도 크리티컬 클래스 이름을 세팅하는함수
    {
        this.PlayerHP = PlayerHP;
        this.PlayerSpeed = PlayerSpeed;
        this.PlayerCritical = PlayerCritical;
        this.PlayerClassName = PlayerClassName;
    }

    public void CurrentPlayer()
    {
        Debug.Log("플레이어 직업: " + this.PlayerClassName);
        Debug.Log("플레이어 체력: " + this.PlayerHP);
        Debug.Log("플레이어 이동속도: " + this.PlayerSpeed);
        Debug.Log("플레이어 크리티컬: " + this.PlayerCritical);
    }

}
