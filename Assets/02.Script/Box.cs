using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    public GameObject[] Weapons; // 무기를 담을 배열

    public Animator animator; // 애니메이터

   private GameObject clone; // 클론 오브젝트

    private int r; // 랜덤
 
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        r = Random.Range(0, 23);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {

            animator.SetBool("Open", true);
            Invoke("InstantiateWeapon", 0f);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(clone);
        }
    }



    void InstantiateWeapon()
    {
        if (r == 0)
        {

            clone = Instantiate(Weapons[0], transform.position, transform.rotation);
         
        }
        if (r == 1)
        {

            clone = Instantiate(Weapons[1], transform.position, transform.rotation);
            
        }
        if (r == 2)
        {

            clone = Instantiate(Weapons[2], transform.position, transform.rotation);

        }
        if (r == 3)
        {

            clone = Instantiate(Weapons[3], transform.position, transform.rotation);

        }
        if (r == 4)
        {

            clone = Instantiate(Weapons[4], transform.position, transform.rotation);

        }
        if (r == 5)
        {

            clone = Instantiate(Weapons[5], transform.position, transform.rotation);

        }
        if (r == 6)
        {

            clone = Instantiate(Weapons[6], transform.position, transform.rotation);

        }
        if (r == 7)
        {

            clone = Instantiate(Weapons[7], transform.position, transform.rotation);

        }
        if (r == 8)
        {

            clone = Instantiate(Weapons[8], transform.position, transform.rotation);

        }
        if (r == 9)
        {

            clone = Instantiate(Weapons[9], transform.position, transform.rotation);

        }
        if (r == 10)
        {
            clone = Instantiate(Weapons[10], transform.position, transform.rotation);

        }
        if (r ==11)
        {

            clone = Instantiate(Weapons[11], transform.position, transform.rotation);

        }
        if (r == 12)
        {

            clone = Instantiate(Weapons[12], transform.position, transform.rotation);

        }
        if (r ==13)
        {

            clone = Instantiate(Weapons[13], transform.position, transform.rotation);

        }
        if (r == 14)
        {

            clone = Instantiate(Weapons[14], transform.position, transform.rotation);

        }
        if (r == 15)
        {

            clone = Instantiate(Weapons[15], transform.position, transform.rotation);

        }
        if (r == 16)
        {

            clone = Instantiate(Weapons[16], transform.position, transform.rotation);

        }
        if (r == 17)
        {

            clone = Instantiate(Weapons[17], transform.position, transform.rotation);

        }
        if (r == 18)
        {

            clone = Instantiate(Weapons[18], transform.position, transform.rotation);

        }
        if (r == 19)
        {

            clone = Instantiate(Weapons[19], transform.position, transform.rotation);

        }
        if (r == 20)
        {

            clone = Instantiate(Weapons[20], transform.position, transform.rotation);

        }
        if (r == 21)
        {

            clone = Instantiate(Weapons[21], transform.position, transform.rotation);

        }
        if (r == 22)
        {

            clone = Instantiate(Weapons[22], transform.position, transform.rotation);

        }
       
    }

}
