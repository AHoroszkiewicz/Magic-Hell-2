using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private float maxHealth;
    private Animator myAnimator;
    private CapsuleCollider2D myCollider;
    private float damage;
    [SerializeField] StatsSO statsSO;
    [SerializeField] float currentHealth;
    [SerializeField] float deathTimer = 3f;

    private void Start()
    {
        damage = statsSO.damage;
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
        Destroy(myCollider);
        myAnimator.SetBool("isDead", true);
        Destroy(gameObject, deathTimer);
    }

    public float GetDamage()
    {
        return damage;
    }
}
