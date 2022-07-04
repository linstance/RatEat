using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHpBar : MonoBehaviour
{
    Image BHP;
    public TextMeshProUGUI BHPText;
    public int BMaxHp;
    public int BNowHp;
    // Start is called before the first frame update
    void Start()
    {
        BMaxHp = 100;
        BNowHp = BMaxHp;
        BHP = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        BHP.fillAmount = BNowHp / 100f;
        BHPText.text = BNowHp.ToString() + "/" + BMaxHp.ToString();
        if(Input.GetKeyDown(KeyCode.A))
        {
            BNowHp -= 10;
        }
    }
}
