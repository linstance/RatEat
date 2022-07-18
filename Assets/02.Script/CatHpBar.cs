using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CatHpBar : MonoBehaviour
{
    Image CHP;
    public TextMeshProUGUI CHPText;
    public GameObject CatHp;
    private int CatMaxHp = 80;
    public static int CatCurrentHp;// Start is called before the first frame update
    void Start()
    {
        CHP = GetComponent<Image>();
        CatCurrentHp = CatMaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        CHP.fillAmount = CatCurrentHp / 80f;
        CHPText.text = CatCurrentHp.ToString() + "/" + CatMaxHp.ToString();
        
        if (CatCurrentHp <= 0)
        {
            CatHp.SetActive(false);
        }
    }

}
