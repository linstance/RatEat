using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float rot_Speed = 360;// 회전되는 스피드
    public Transform pos;// 발사될 위치
    public GameObject bullet;// 옵젝

    public static Vector2 pos2;

    public float cool;
    float time;

    void Update()
    {
        pos2 = new Vector2(pos.position.x, pos.position.y);

        time += Time.deltaTime;
        if(time > cool)
        {
            time = 0;
            Instantiate(bullet, transform.position, Quaternion.identity);

            bullet.transform.position = transform.position;

            //총알의 방향을 오브젝트의 방향으로 한다.
            //->해당 오브젝트가 오브젝트가 360도 회전하고 있으므로, Rotation이 방향이 됨.
            bullet.transform.rotation = transform.rotation;

            
        }

        
        transform.Rotate(Vector3.forward * rot_Speed * 3 * Time.deltaTime);





    }

    
}
