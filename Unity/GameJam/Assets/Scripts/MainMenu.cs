using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }
    public void PlayLevel2()
    {
        SceneManager.LoadScene("Scenes/Level2");
    }
    public void PlayLevel3()
    {
        SceneManager.LoadScene("Scenes/Level3");
    }

    public void PlayLevel4()
    {
        SceneManager.LoadScene("Scenes/Level4");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
