using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private bool isLife;
    private Animator Catanimator;
    // Start is called before the first frame update
    void Start()
    {
        isLife = true;
        Catanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CatHpBar.CatCurrentHp <= 0)
        {
            Catanimator.SetTrigger("is_Die");
            Invoke("CatDie", 1f);
            isLife = false;
        }
    }
    public void DogTakeDamage(int Damage)
    {
        CatHpBar.CatCurrentHp = CatHpBar.CatCurrentHp - Damage;
    }
    public void CatDie()
    {
        gameObject.SetActive(false);
    }
}
