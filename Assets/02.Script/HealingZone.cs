using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            WarriorController.WarrorHP += 100;
            WarriorController.WarrorMP += 100;
        }
    }

}
