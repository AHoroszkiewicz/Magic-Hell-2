using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] GameObject deathMenu;
    [SerializeField] GameObject pauseButton;
    [SerializeField] Animator playerAnimator;
    private float timer;
    private bool onetime = false;

    private void Update()
    {
        if (playerAnimator.GetBool("isDead") && !onetime)
        {
            timer += Time.deltaTime;
            if(timer>1)
            {
                Time.timeScale = 0f;
                deathMenu.SetActive(true);
                pauseButton.SetActive(false);
                onetime = true;
            }
        }
    }
}
