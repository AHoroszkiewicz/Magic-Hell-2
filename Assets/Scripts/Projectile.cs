using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] NearestEnemy nearestEnemy;
    private Transform target;

    private void Start()
    {
        target = nearestEnemy.GetNearestEnemy();
        Debug.Log(target);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            MoveTowardsTarget();
            RotateTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void RotateTowardsTarget()
    {
        var offset = 0f;
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
        transform.localScale = new Vector2(1f, Mathf.Sign(target.position.x - transform.position.x));
    }
}
