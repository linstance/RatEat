using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    public bool isRotate;

    void Update()
    {
        if (isRotate)
            transform.Rotate(Vector3.forward * 3);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BorderLine") //총알이 BorderLine이라는 옵젝에 닿으면 삭제되게 만듬.
        {
            gameObject.SetActive(false);
        }

        if (collision.CompareTag("Player") )
        {
            //collision.GetComponent<WarriorController>().Takedamage(damage);//총알이 PLayer와 닿으면 데미지가 들어가게 설정

            //Destroy(gameObject);
        }
    }

    
}
