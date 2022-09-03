using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] StatsSO statsSO;
    private float maxHealth;
    [SerializeField] float currentHealth;

    void Start()
    {
        maxHealth = statsSO.health;
        currentHealth = maxHealth;
    }
}
