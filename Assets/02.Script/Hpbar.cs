using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Hpbar : MonoBehaviour
{
    Image Healthbar;
    public TextMeshProUGUI HPtext;
    int maxHealth;
    public int health;
    // Start is called before the first frame update
    void Start()
    {

        maxHealth += WarriorController.WarrorHP;
        Healthbar = GetComponent<Image>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.fillAmount = health / maxHealth;
        HPtext.text = health.ToString() + "/" + maxHealth.ToString();
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
