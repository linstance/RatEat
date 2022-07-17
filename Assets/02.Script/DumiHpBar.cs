using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DumiHpBar : MonoBehaviour
{
    Image DumiHp;
    public static int DMHealth;
    public static int DCHealth;// Start is called before the first frame update
    void Start()
    {
        DMHealth += 10;
        DumiHp = GetComponent<Image>();
        DCHealth = DMHealth;
    }

    // Update is called once per frame
    void Update()
    {
        DumiHp.fillAmount = DCHealth / 10;

        if(DCHealth <= 0)
        {
            DCHealth += DMHealth;
        }
    }
}
