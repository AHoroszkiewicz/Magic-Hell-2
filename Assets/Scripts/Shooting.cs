using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float fireRate;
    [SerializeField] GameObject projectile;
    [SerializeField] NearestEnemy nearestEnemy;
    private Transform inRange;

    private void Start()
    {
        StartCoroutine(ProjectileSpawn());
    }

    private IEnumerator ProjectileSpawn()
    {
        yield return new WaitForSeconds(fireRate);
        inRange = nearestEnemy.GetNearestEnemy();
        if (inRange != null)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
        }
    }
}
