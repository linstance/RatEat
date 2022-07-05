using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    private bool isRotate;
    Rigidbody2D rigid;
    //public Transform pos;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        
        if (isRotate)
        {
            transform.Rotate(Vector3.forward * 3);
        }
        

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("BorderLine"))//총알이 BorderLine이라는 옵젝에 닿으면 삭제되게 만듬.
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player") )
        {

            Destroy(gameObject);
        }
    }

    
}
