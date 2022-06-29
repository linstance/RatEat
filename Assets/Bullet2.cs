using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;
    

    public static int currentHP;


    void Start()
    {
        Invoke("DestroyBullet", 1);
        
         WarriorController.currentHP -= currentHP ;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLayer);
        if (raycast.collider != null)
        {
            if(raycast.collider.tag == "Player")
            {
                Debug.Log("당했다");
                currentHP -= 1;
            }
            DestroyBullet();
        }
        transform.Translate(transform.right * -1f * speed * Time.deltaTime);


    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
