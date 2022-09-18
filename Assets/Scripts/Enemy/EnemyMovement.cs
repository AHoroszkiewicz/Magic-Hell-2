using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    [SerializeField] float speed = 10f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        Run();
        FlipSprite();
    }
    
    private void Run()
    {
        if (!myAnimator.GetBool("isDead"))
        {
                myRigidbody.velocity =
            (target.transform.position - transform.position).normalized * speed;  
        }
    }

    private void FlipSprite()
    {
            transform.localScale = new Vector2(Mathf.Sign(target.position.x - transform.position.x), 1f);
    }

}

