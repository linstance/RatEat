using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject MenuBar;
    public GameObject Buttons;
    public GameObject UIShadow;

    private void Update()
    {
       if(Input.GetKey(KeyCode.Escape))
        {
            MenuBar.SetActive(true);
            Buttons.SetActive(true);
            UIShadow.SetActive(true);
        }
    }

    public void PlayBtn()
    {
        SceneManager.LoadScene("Main");
    }

    public void HomeBtn()
    {
        SceneManager.LoadScene("Title");
    }

    public void ReStartBtn()
    {
        MenuBar.SetActive(false);
        Buttons.SetActive(false);
        UIShadow.SetActive(false);
    }

}
