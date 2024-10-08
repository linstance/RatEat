﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Hpbar : MonoBehaviour
{
    Image Healthbar;
    public TextMeshProUGUI HPtext;
    private int maxHealth;
    //private int health;
    private int isCurrentHP;


    // Start is called before the first frame update
    void Start()
    {
        
        maxHealth += WarriorController.WarrorHP;
        Healthbar = GetComponent<Image>();
        isCurrentHP = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        isCurrentHP = WarriorController.currentHP;
        Healthbar.fillAmount = isCurrentHP / 10f;
        HPtext.text = isCurrentHP.ToString() + "/ 10";
        if (isCurrentHP > maxHealth)
        {
            isCurrentHP = maxHealth;
        }
    }
}
