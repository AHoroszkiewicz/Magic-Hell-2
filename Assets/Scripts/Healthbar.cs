using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] StatsSO statsSO;
    private Image healthBar;
    private float maxHealth;
    [SerializeField] float currentHealth;

    void Start()
    {
        healthBar = GetComponent<Image>();
        maxHealth = statsSO.health;
        currentHealth = maxHealth;
    }

    void Update()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
