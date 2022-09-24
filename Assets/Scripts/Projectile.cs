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
    //
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<EnemyStats>() != null)
            {
                collision.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
            }
        }
    }
}
