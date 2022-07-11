﻿
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    private void OnTriggerStay2D(collision2D collision )
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
            
            if ( WarriorController.currentHP == 10 && WarriorController.currentMP == 150)
            {
                anim.StopPlayBack("HealingZone");
            }
        }


    }

}
