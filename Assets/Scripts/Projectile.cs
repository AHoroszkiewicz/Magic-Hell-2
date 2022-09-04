using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage;
    [SerializeField] StatsSO statsSO;

    private void Start()
    {
        damage = statsSO.damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<EnemyHealth>() != null)
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
        }
    }
}
