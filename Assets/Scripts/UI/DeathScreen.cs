using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] GameObject deathMenu;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject joystick;

    public void EnableScreen(float value)
    {
        Invoke("Screen",value);
    }

    private void Screen()
    {
        Time.timeScale = 0f;
        deathMenu.SetActive(true);
        pauseButton.SetActive(false);
        joystick.SetActive(false);
    }
}
