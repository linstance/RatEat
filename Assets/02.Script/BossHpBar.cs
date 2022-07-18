using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;



public class BossHpBar : MonoBehaviour
{
    Image BHP;
    public TextMeshProUGUI BHPText;
    private int DogmaxHealth;
    private int isDogCurrentHP;
    // Start is called before the first frame update
    void Start()
    {
        DogmaxHealth += Dog.CurDogHp;
        BHP = GetComponent<Image>();
        isDogCurrentHP = DogmaxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        isDogCurrentHP = Dog.CurDogHp;
        BHP.fillAmount = isDogCurrentHP / 50f;
        BHPText.text = isDogCurrentHP.ToString() + "/ 50";
        
        if (isDogCurrentHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
