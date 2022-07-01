using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStat
{
    // 무기의 능력치를 담고있는 스크립트
    public int WeaponMPValue { get; set; }
    public int WeaponDamage { get; set; }//무기의 공격력
    public string WeaponName { get; set; }//무기의 이름
 
    public WeaponStat(int WeaponDamage, int WeaponMPValue, string WeaponName)
    {
        this.WeaponMPValue = WeaponMPValue;
        this.WeaponDamage = WeaponDamage;
        this.WeaponName = WeaponName;
    }
}
