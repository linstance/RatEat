﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat
{
    public int PlayerHP { get; set; }
    public int PlayerMP { get; set; }
    public float PlayerSpeed { get; set; } //플레이어 속도
    public string PlayerClassName { get; set; } //플레이어 클래스 이름


    public PlayerStat(int PlayerHP, int PlayerMP, float PlayerSpeed, string PlayerClassName)//플레이어의 체력 이동속도 크리티컬 클래스 이름을 세팅하는함수
    {
        this.PlayerHP = PlayerHP;
        this.PlayerMP = PlayerMP;
        this.PlayerSpeed = PlayerSpeed;
        this.PlayerClassName = PlayerClassName;
    }

    public void CurrentPlayer()
    {
        Debug.Log("플레이어 직업: " + this.PlayerClassName);
        Debug.Log("플레이어 체력: " + this.PlayerHP);
        Debug.Log("플레이어 마나" + this.PlayerMP);
        Debug.Log("플레이어 이동속도: " + this.PlayerSpeed);
    }

}
