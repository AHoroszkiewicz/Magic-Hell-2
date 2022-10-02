using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject joystick;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
        ResumeButton();
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        joystick.SetActive(false);
    }    

    public void ResumeButton()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        levelMenu.SetActive(false);
        joystick.SetActive(true);
        joystick.GetComponent<MovementJoystick>().PointerUp();
        pauseButton.SetActive(true);
    }
}
