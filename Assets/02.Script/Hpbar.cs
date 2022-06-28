using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Hpbar : MonoBehaviour
{
    Image Healthbar;
    public TextMeshProUGUI HPtext;
    float maxHealth = 10;
    public static float health;
    // Start is called before the first frame update
    void Start()
    {
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
