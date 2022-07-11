using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(WarriorController.currentHP == 10)
            WarriorController.currentHP += 0;
            else
            WarriorController.currentHP += 1;

            if (WarriorController.currentMP == 150)
                WarriorController.currentMP += 0;
            else
                WarriorController.currentMP += 1;
            
        }


    }

}
