using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;
    void Start()
    {
        Invoke("DestroyBullet", 2);
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
