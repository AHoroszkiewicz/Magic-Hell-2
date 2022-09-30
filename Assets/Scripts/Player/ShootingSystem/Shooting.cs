using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] List<GameObject> projectiles;
    [SerializeField] NearestEnemy nearestEnemy;
    private Transform target;

    private void Start()
    {
        StartCoroutine(EvilProjectileSpawn());
    }

    private IEnumerator EvilProjectileSpawn()
    {
        while (true)
        {//
            for (int i=0; i<projectiles.Count; i++)
            {
                if (projectiles[i].name == "EvilStaffProjectile")
                {
                    GameObject evilProjectile = projectiles[i];
                    int level = evilProjectile.GetComponent<Projectile>().GetLevel();
                    float EvilFireRate = evilProjectile.GetComponent<Projectile>().GetBaseFireRate();
                    target = nearestEnemy.GetNearestEnemy();
                    if (target != null && level>0)
                    {
                        var newProjectile = Instantiate(evilProjectile, transform.position, Quaternion.Euler(Vector3.forward * (RotateTowardsTarget())));
                        evilProjectile.transform.localScale = new Vector2(1f, Mathf.Sign(target.position.x - transform.position.x));
                        MoveTowardsTarget(newProjectile);
                        Destroy(newProjectile, 3f);
                        yield return new WaitForSeconds(EvilFireRate);
                    }
                    else
                    {                
                        yield return new WaitForSeconds(EvilFireRate);
                    }
                }
                yield return null;
            }
        }
    }

    private float RotateTowardsTarget()
    {
        var offset = 0f;
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return offset + angle;
    }

    private void MoveTowardsTarget(GameObject projectile)
    {
        projectile.GetComponent<Rigidbody2D>().velocity = 
            (target.transform.position - transform.position).normalized * projectileSpeed;
    }
}
