using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float maxHealth;
    private Animator myAnimator;
    [SerializeField] StatsSO statsSO;
    [SerializeField] float currentHealth;
    [SerializeField] float deathTimer = 3f;

    private void Start()
    {
        maxHealth = statsSO.health;
        currentHealth = maxHealth;
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Die();
    }

    private void Die()
    {
        if (currentHealth <= 0)
        {
            myAnimator.SetBool("isDead", true);
            Destroy(gameObject, deathTimer);
        }
    }
}
