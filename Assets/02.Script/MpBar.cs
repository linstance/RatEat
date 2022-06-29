using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MpBar : MonoBehaviour
{
    Image ManaBar;
    public TextMeshProUGUI MPtext;
    public int maxMana;
    public int CurrentMP;
    // Start is called before the first frame update
    void Start()
    {
        maxMana += WarriorController.WarrorMP;
        ManaBar = GetComponent<Image>();
        CurrentMP = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentMP = WarriorController.currentMP;
        ManaBar.fillAmount = CurrentMP / 150f;
        MPtext.text = CurrentMP.ToString() + "/" + WarriorController.WarrorMP.ToString();
        if (CurrentMP > maxMana)
        {
            CurrentMP = maxMana;
        }
    }
}
