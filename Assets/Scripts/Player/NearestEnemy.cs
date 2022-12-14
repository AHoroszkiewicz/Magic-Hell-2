using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestEnemy : MonoBehaviour
{
    public Transform Player;
    public float OverlapRadius = 10.0f;

    private Transform nearestEnemy;
    private int enemyLayer;

    private void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    private void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(Player.position, OverlapRadius, 1 << enemyLayer);
        float minimumDistance = Mathf.Infinity;
        foreach (Collider2D collider in hitColliders)
        {
            float distance = Vector3.Distance(Player.position, collider.transform.position);
            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestEnemy = collider.transform;
            }
        }
    }

    public Transform GetNearestEnemy()
    {
        return nearestEnemy;
    }
}
