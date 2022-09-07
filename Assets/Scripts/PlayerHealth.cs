using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
        StartCoroutine(TakingDamage());
        healthBar = healthBarObject.GetComponent<Image>();
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
            myAnimator.SetBool("isRunning", false);
            myAnimator.SetBool("isDead", true);
        }
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

    private IEnumerator TakingDamage()
    {
        while (true)
        {
            if (enemyDamage > 0)
            {
                TakeDamage(enemyDamage);
                yield return new WaitForSeconds(immunityTime);
            }
            else
            {
                yield return null;
            }
        }
    }
    
    private void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            currentHealth -= damage;
            enemyDamage = 0f;
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
