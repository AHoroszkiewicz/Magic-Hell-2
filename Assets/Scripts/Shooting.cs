using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] int fireRate = 1;
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] GameObject projectile;
    [SerializeField] NearestEnemy nearestEnemy;
    private Transform target;

    private void Start()
    {
        StartCoroutine(ProjectileSpawn());
    }

    private IEnumerator ProjectileSpawn()
    {
        while (true)
        {
            target = nearestEnemy.GetNearestEnemy();
            if (target != null)
            {
                var newProjectile = Instantiate(projectile, transform.position, Quaternion.Euler(Vector3.forward * (RotateTowardsTarget())));
                projectile.transform.localScale = new Vector2(1f, Mathf.Sign(target.position.x - transform.position.x));
                MoveTowardsTarget(newProjectile);
                Destroy(newProjectile, 3f);
                yield return new WaitForSeconds(fireRate);
            }
            else
            {                
                yield return new WaitForSeconds(fireRate);
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
        //transform.position = Vector2.MoveTowards(transform.position, target.position, projectileSpeed * Time.deltaTime);
        projectile.GetComponent<Rigidbody2D>().velocity = 
            (target.transform.position - transform.position).normalized * projectileSpeed;
    }
}
