using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public void OnResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnReturnToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main Menu");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
