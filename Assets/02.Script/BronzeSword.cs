using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BronzeSword : MonoBehaviour
{
    // Start is called before the first frame update

    public int WeaponMPValue; //무기 마나 소모값
    public int WeaponDamage;//무기의 공격력
    public string WeaponName;//무기의 이름


    void Start()
    {
        WeaponStat weaponStat = new WeaponStat(8, 1, "BronzeSword");
    }
  
}
