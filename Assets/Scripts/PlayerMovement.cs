using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private Vector2 Input;
    [SerializeField] float moveSpeed = 10f;
    private NearestEnemy nearestEnemy;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Run();
        FlipSprite();
        //Debug.Log(nearestEnemy.GetNearestEnemy());
    }

    private void Run()
    {
        if (!myAnimator.GetBool("isDead"))
            {
            Vector2 playerVelocity = new Vector2(Input.x * moveSpeed, Input.y * moveSpeed);
            myRigidbody.velocity = playerVelocity;
    
            bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

            bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
            if (playerHasHorizontalSpeed)
            {
               myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
            }
            else if(playerHasVerticalSpeed)
            {
                myAnimator.SetBool("isRunning", playerHasVerticalSpeed);
            }
            else
            {
                myAnimator.SetBool("isRunning", false);
            }
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }

    }

    private void OnMove(InputValue value)
    {
        Input = value.Get<Vector2>();
    }
}
