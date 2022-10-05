using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage;
    private int level;
    private Animator myAnimator;
    [SerializeField] StatsSO statsSO;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        level = statsSO.level;
        damage = statsSO.damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(GetComponent<CircleCollider2D>());
        Destroy(GetComponent<Rigidbody2D>());
        myAnimator.SetBool("isDestroyed", true);
        Destroy(gameObject, 1);
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<EnemyStats>() != null)
            {
                collision.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
            }
        }
    }

    public float GetBaseFireRate()
    {
        if (level == 0)
        {
            return 0;
        }
        float baseFireRate = statsSO.baseFireRate;
        float fixedFireRate = 1/baseFireRate;
        if (level>0)
        {
            fixedFireRate = fixedFireRate / level;
        }
        return fixedFireRate;
    }

    public int GetLevel()
    {
        return level;
    }

    public void LevelUp()
    {
        level++;
    }
}
