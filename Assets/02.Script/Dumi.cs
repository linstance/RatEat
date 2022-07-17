using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumi : MonoBehaviour
{
    public GameObject prfHp;
    public GameObject canvas;

    RectTransform hpBar;
    public float height = 1f;// Start is called before the first frame update
    void Start()
    {
        hpBar = Instantiate(prfHp, canvas.transform).GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _hpBarPos =
            Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        hpBar.position = _hpBarPos;
    }
    public void takeAntDamage(int Damage)
    {
        DumiHpBar.DCHealth = DumiHpBar.DCHealth - Damage;
    }
}
