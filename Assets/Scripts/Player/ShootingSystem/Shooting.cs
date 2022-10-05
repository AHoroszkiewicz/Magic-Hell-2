using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    public List<GameObject> projectiles;
    [SerializeField] NearestEnemy nearestEnemy;
    private Transform target;
    private float fireRate;

    private void Start()
    {
        StartCoroutine(EvilProjectileSpawn());
        StartCoroutine(FireBallSpawn());
    }

    private IEnumerator EvilProjectileSpawn()
    {
        while (true)
        {
            for (int i=0; i<projectiles.Count; i++)
            {
                if (projectiles[i].name == "EvilStaffProjectile")
                {
                    ProjectileSpawn(i);
                    yield return new WaitForSeconds(fireRate);
                }
                yield return null;
            }
        }
    }

    private IEnumerator FireBallSpawn()
    {
        while (true)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                if (projectiles[i].name == "FireStaffProjectile")
                {
                    ProjectileSpawn(i);
                    yield return new WaitForSeconds(fireRate);
                }
                yield return null;
            }
        }
    }

    private void ProjectileSpawn(int listIndex)
    {
        GameObject projectile = projectiles[listIndex];
        int level = projectile.GetComponent<Projectile>().GetLevel();
        fireRate = projectile.GetComponent<Projectile>().GetBaseFireRate();
        target = nearestEnemy.GetNearestEnemy();
        if (target != null && level > 0)
        {
            var newProjectile = Instantiate(projectile, transform.position, Quaternion.Euler(Vector3.forward * (RotateTowardsTarget())));
            projectile.transform.localScale = new Vector2(1f, Mathf.Sign(target.position.x - transform.position.x));
            MoveTowardsTarget(newProjectile);
            Destroy(newProjectile, 3f);
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
