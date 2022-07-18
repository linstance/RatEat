using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;

    
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("go");
            SceneManager.LoadScene(nextSceneName);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
