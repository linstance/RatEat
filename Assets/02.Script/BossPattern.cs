using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossPattern : MonoBehaviour
{
    public GameObject Bullet;

    int count = 15;
    private BoxCollider2D area;
    private List<GameObject> BulletList = new List<GameObject>();

    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        StartCoroutine("Spawn", 20);
        
    }

    IEnumerator Spawn(float delayTime)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPos = GetRandomPosition();

            GameObject instance = Instantiate(Bullet, spawnPos, Quaternion.identity);
            BulletList.Add(instance);
        }
        area.enabled = false;
        yield return new WaitForSeconds(delayTime);

        for (int i = 0; i < count; i++)
            Destroy(BulletList[i].gameObject);

        BulletList.Clear();
        area.enabled = true;
        StartCoroutine("Spawn", 20);

    }

    private Vector2 GetRandomPosition()
    {
        Vector2 basePosition = transform.position;  //오브젝트의 위치
        Vector2 size = area.size;                   //box colider2d, 즉 맵의 크기 벡터

        //x, y축 랜덤 좌표 얻기
        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

        Vector2 spawnPos = new Vector2(posX, posY);

        return spawnPos;
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if ( coll.gameObject.name == "Bullet(Clone)")
        {
            Destroy(Bullet);
        }
    }
}
