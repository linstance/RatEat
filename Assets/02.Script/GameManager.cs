using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(Player);
        DontDestroyOnLoad(MainCamera);
        DontDestroyOnLoad(GM);
        DontDestroyOnLoad(HPbar);
    }

}
