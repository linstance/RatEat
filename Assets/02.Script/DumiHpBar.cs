using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DumiHpBar : MonoBehaviour
{
    Image DumiHp;
    private int DMHealth = 10;
    public static int DCHealth;// Start is called before the first frame update
    void Start()
    {
        DCHealth = DMHealth;
        DumiHp = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        DumiHp.fillAmount = DCHealth / 10f;

        if(DCHealth <= 0)
        {
            DCHealth = DMHealth;
        }

    }
}
