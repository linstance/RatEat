using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
