using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;
    public GameObject MainCamera;
    public GameObject GM;
    public GameObject HPbar;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(WarriorController.currentHP <= 0)
        {
            Invoke("DestroyGM", 0.9f);
            Invoke("Ds", 0.91f);
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(Player);
        DontDestroyOnLoad(MainCamera);
        DontDestroyOnLoad(GM);
        DontDestroyOnLoad(HPbar);
    }

    private void DestroyGM()
    {
        Destroy(HPbar);
        SceneManager.LoadScene("Game Over");
    }

    private void Ds()
    {
        Destroy(Player);
        Destroy(MainCamera);
        Destroy(gameObject);
    }

}
