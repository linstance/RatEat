using System.Collections;
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
        
        HPtext.text = isCurrentHP.ToString() + "/" + maxHealth.ToString();
        if (isCurrentHP > maxHealth)
        {
            isCurrentHP = maxHealth;
        }
    }
}
