using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float maxHealth;
    private Animator myAnimator;
    private CapsuleCollider2D myCollider;
    [SerializeField] StatsSO statsSO;
    [SerializeField] float currentHealth;
    [SerializeField] float deathTimer = 3f;

    private void Start()
    {
        maxHealth = statsSO.health;
        currentHealth = maxHealth;
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    { 
            myAnimator.SetBool("isDead", true);
            Destroy(gameObject, deathTimer);
    }
}
