using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hpbar : MonoBehaviour
{
    Image Healthbar;
    float maxHealth = 200;
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
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
