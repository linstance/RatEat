using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMash : MonoBehaviour
{
    private GameObject Target;

    public Collider2D AttackMash;   //공격범위
    public Collider2D TrackingMash; //추적범위


    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
