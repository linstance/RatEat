
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collider )
    {
        if(collider.CompareTag("Player"))
        {
            animator.SetTrigger("HealingZone");
            
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
