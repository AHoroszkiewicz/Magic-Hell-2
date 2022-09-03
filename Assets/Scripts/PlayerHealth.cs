using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] StatsSO statsSO;
    private Image healthBar;
    private float maxHealth;
    [SerializeField] float currentHealth;
    [SerializeField] Animator myAnimator;

    private void Start()
    {
        healthBar = GetComponent<Image>();
        maxHealth = statsSO.health;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        HealthBar();
        Die();
    }

    private void Die()
    {
        if (currentHealth <= 0)
        {
            myAnimator.SetBool("isDead", true);
        }
    }

    private void HealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
