using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    private Image healthBar;
    private float maxHealth;
    private float enemyDamage;
    [SerializeField] StatsSO statsSO;
    [SerializeField] GameObject healthBarObject;
    [SerializeField] Animator myAnimator;
    [SerializeField] float immunityTime;
    [SerializeField] float currentHealth;
    public UnityEvent onDeath;

    private void Start()
    {
        healthBar = healthBarObject.GetComponent<Image>();
        maxHealth = statsSO.health;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        TakeDamage();
        HealthBar();
        if (currentHealth <= 0)
        {
            onDeath.Invoke();
        }
    }

    public void Die()
    {
            myAnimator.SetBool("isRunning", false);
            myAnimator.SetBool("isDead", true);
    }

    private void HealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<EnemyStats>() != null)
            {
                enemyDamage = collision.gameObject.GetComponent<EnemyStats>().GetDamage();
            }
        }
    }
    
    private void TakeDamage()
    {
        if (enemyDamage > 0)
        {
            currentHealth -= enemyDamage;
            enemyDamage = 0f;
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
