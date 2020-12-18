using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    private bool clickedPause;
    public GameObject gameManagment;
    public GameObject gameMenu;

    void Update()
    {
        if(clickedPause)
        {
            Time.timeScale = 0f;
            clickedPause = false;
            gameManagment.SetActive(false);
            gameMenu.SetActive(true);
        }
    }
    public void ClickedPause()
    {
        clickedPause = true;
    }
    public void ResumeClick()
    {
        clickedPause = false;
        gameMenu.SetActive(false);
        gameManagment.SetActive(true);
        Time.timeScale = 1f;
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

}
