using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D myRigidbody;
    [SerializeField] float stoppingDistance = 1f;
    [SerializeField] float speed = 10f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    
    private void Update()
    {
        Run();
        FlipSprite();
    }
    
    private void Run()
    {
        if (Vector2.Distance(transform.position, target.position) >= stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void FlipSprite()
    {
            transform.localScale = new Vector2(Mathf.Sign(target.position.x - transform.position.x), 1f);
    }

}

